using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace Discount.Infrastructure.Extensions
{
    public static class DbExtension
    {
        public static IHost MigrateDatabase<TContext>(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var config = services.GetRequiredService<IConfiguration>();
                var logger = services.GetRequiredService<ILogger<TContext>>();
                try
                {
                    logger.LogInformation("Начата миграция базы данных Discount DB");
                    ApplyMigrations(config);
                    logger.LogInformation("Миграция базы данных Discount DB завершена");
                }
                catch(Exception ex)
                {
                    logger.LogError(ex, "Произошла ошибка при миграции базы данных.");
                    throw;
                }
            }
            return host;
        }

        private static void ApplyMigrations(IConfiguration config)
        {
            var retry = 5;
            while (retry > 0)
            {
                try
                {
                    using var connection = new NpgsqlConnection(config.GetValue<string>("DatabaseSettings:ConnectionString"));
                    connection.Open();
                    using var cmd = new NpgsqlCommand
                    {
                        Connection = connection
                    };
                    cmd.CommandText = "DROP TABLE IF EXISTS Coupon";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = @"
                CREATE TABLE Coupon(
                    Id SERIAL PRIMARY KEY,
                    ProductName VARCHAR(200) NOT NULL,
                    Description TEXT,
                    Amount INT
                    )";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "INSERT INTO Coupon(ProductName, Description, Amount) VALUES('Кроссовки Adidas Performance Crazyflight 6', 'Скидка на обувь', 500)";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "INSERT INTO Coupon(ProductName, Description, Amount) VALUES('Кроссовки Adidas Performance Novaflight 2', 'Запросить скидку', 700)";
                    cmd.ExecuteNonQuery();

                    //Exit loop if successful
                    break;
                }
                catch (Exception ex)
                {
                    retry--;
                    if(retry == 0)
                    {
                        throw;
                    }
                    // wait for 2 seconds
                    Thread.Sleep(2000);
                }
            } 
        }
    }
}
