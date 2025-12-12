using Microsoft.EntityFrameworkCore;
using Ordering.Core.Common;
using Ordering.Core.Entities;

namespace Ordering.Infrastructure.Data
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext>options):base(options)
        {
            
        }
        public DbSet<Order> orders { get; set; }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesonSuccess, CancellationToken cancellationToken = default)
        {
            foreach(var entry in ChangeTracker.Entries<EntityBase>())
            {
                switch(entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = "hasan"; // TODO: Replace with auth server
                        break;
                    case EntityState.Modified:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = "hasan"; // TODO: Replace with auth server
                        break;
                }
            }
            return base.SaveChangesAsync(acceptAllChangesonSuccess, cancellationToken);
        }
    }
}
