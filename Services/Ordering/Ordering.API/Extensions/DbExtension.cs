using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Polly;

namespace Ordering.API.Extensions
{
    public static class DbExtension
    {
        public static IHost MigrationDatabase<TContext>(this IHost host, Action<TContext, IServiceProvider> seeder)
            where TContext : DbContext
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var logger = services.GetRequiredService<ILogger<TContext>>();
                var context = services.GetService<TContext>();

                try
                {
                    logger.LogInformation($"Начата миграция базы данных: {typeof(TContext).Name}");
                    // retry strategy
                    var retry = Policy.Handle<SqlException>()
                        .WaitAndRetry(
                        retryCount: 5,
                        sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                        onRetry: (exception, span, count) =>
                        {
                            logger.LogError($"Повторная попытка из-за {exception} {span}");

                        });
                    retry.Execute(() => CallSeedr(seeder, context, services));
                    logger.LogInformation($"Миграция завершена: {typeof(TContext).Name}");
                }
                catch ( Exception ex )
                {
                    logger.LogError(ex, $"Произошла ошибка при миграции базы данных: {typeof(TContext).Name}");
                }
            }
            return host;
        }

        private static void CallSeedr<TContext>(Action<TContext, IServiceProvider> seeder, TContext? context, IServiceProvider services) where TContext : DbContext
        {
            context.Database.Migrate();
            seeder(context, services);
        }
    }
}
