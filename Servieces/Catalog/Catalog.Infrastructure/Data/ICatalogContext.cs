using Catalog.Core.Entities;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data
{
    public interface ICatalogContext
    {
        // MongoDB collection for Products entities
        IMongoCollection<Product> Products { get; }

        // MongoDB collection for Products entities
        IMongoCollection<ProductBrand> Brands { get; }

        // MongoDB collection for ProductType entities
        IMongoCollection<ProductType> Types { get; }
    }
}
