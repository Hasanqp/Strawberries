using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Core.Ripositories;
using Ordering.Infrastructure.Data;
using Ordering.Infrastructure.Repositories;

namespace Ordering.Infrastructure.Extensions
{
    public static class InfraServices
    {
        public static IServiceCollection AddInfaServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<OrderContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("OrderingConnectionString")));
            serviceCollection.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            serviceCollection.AddScoped<IOrderRepository, OrderRepository>();
            return serviceCollection;
        }
    }
}
