using Catalog.Core.Entities;

namespace Catalog.Core.Repositories
{
    public interface IProductRepository
    {
        // Get all products
        Task<IEnumerable<Product>> GetProducts();
        // Get a specific product by ID
        Task<Product> GetProduct(string id);
        // Get products by name
        Task<IEnumerable<Product>> GetProductsByName(string name);
        // Get products by brand name
        Task<IEnumerable<Product>> GetProductsByBrand(string brandName);
        // Create a new product
        Task<Product> CreateProduct(Product product);
        // Update a product
        Task<bool> UpdateProduct(Product product);
        // Delete a product
        Task<bool> DeleteProduct(string id);
    }
}
