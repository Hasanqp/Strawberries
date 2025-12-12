using Microsoft.Extensions.Logging;
using Ordering.Core.Entities;

namespace Ordering.Infrastructure.Data
{
    public class OrderContextSeed 
    {
        public static async Task SeedAsync(OrderContext orderContext, ILogger<OrderContextSeed> logger)
        {
            if(!orderContext.Orders.Any())
            {
                orderContext.Orders.AddRange(GetOrders());
                await orderContext.SaveChangesAsync();
                logger.LogInformation($"Ordering Database: {typeof(OrderContext).Name} seeded!!!");
            }
        }

        private static IEnumerable<Order> GetOrders()
        {
            return new List<Order>
            {
                new()
                {
                    UserName = "hasan",
                    FirstName = "hasan",
                    LastName = "ali",
                    EmailAddress = "hasanali@Strawberries.net",
                    AddressLine = "Moskovskaya Ulitsa 1, Kirov",
                    Country = "Russia",
                    TotalPrice = 750,
                    State = "KIR",
                    ZipCode = "610020",

                    CardName = "Mir",
                    CardNumber = "1098765432123456",
                    CreatedBy = "Hasan",
                    Expiration = "12/12",
                    Cvv = "101",
                    PaymentMethod = 1,
                    LastModifiedBy = "Hasan",
                    LastModifiedDate = new DateTime(),
                }
            };
        }
    }
}
