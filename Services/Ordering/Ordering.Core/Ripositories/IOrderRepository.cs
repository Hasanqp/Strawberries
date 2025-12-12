using Ordering.Core.Entities;

namespace Ordering.Core.Ripositories
{
    public interface IOrderRepository : IAsyncRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrdersByUserName(string userName);
    }
}
