using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using Catalog.Infrastructure.Data;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository, IBrandRepository, ITypesRepository
    {
        // Dependency injection of catalog context for database access
        public ICatalogContext _context { get; }

        // Constructor to initialize the repository with database context
        public ProductRepository(ICatalogContext context)
        {
            _context = context;
        }

        // IProductRepository implementation: Get a specific product by ID
        async Task<Product> IProductRepository.GetProduct(string id)
        {
            return await _context
                .Products
                .Find(p => p.Id == id)
                .FirstOrDefaultAsync();
        }

        // IProductRepository implementation: Get all products
        async Task<IEnumerable<Product>> IProductRepository.GetProducts()
        {
            return await _context
                .Products
                .Find(p => true)
                .ToListAsync();
        }

        // IProductRepository implementation: Get products by brand name (case-insensitive)
        async Task<IEnumerable<Product>> IProductRepository.GetProductsByBrand(string brandName)
        {
            return await _context
                .Products
                .Find(p => p.Brands.Name.ToLower() == brandName.ToLower())
                .ToListAsync();
        }

        // IProductRepository implementation: Get products by product name (case-insensitive)
        async Task<IEnumerable<Product>> IProductRepository.GetProductsByName(string name)
        {
            return await _context
                .Products
                .Find(p => p.Name.ToLower() == name.ToLower())
                .ToListAsync();
        }

        // IProductRepository implementation: Create a new product
        async Task<Product> IProductRepository.CreateProduct(Product product)
        {
            await _context.Products.InsertOneAsync(product);
            return product;
        }

        // IProductRepository implementation: Delete a product by ID
        async Task<bool> IProductRepository.DeleteProduct(string id)
        {
            var deleteProduct = await _context
                .Products
                .DeleteOneAsync(p => p.Id == id);
            return deleteProduct.IsAcknowledged && deleteProduct.DeletedCount > 0;
        }

        // IProductRepository implementation: Update an existing product
        async Task<bool> IProductRepository.UpdateProduct(Product product)
        {
            var updatedProduct = await _context
                .Products
                .ReplaceOneAsync(p => p.Id == product.Id, product);
            return updatedProduct.IsAcknowledged && updatedProduct.ModifiedCount > 0;
        }

        // IBrandRepository implementation: Get all product brands
        async Task<IEnumerable<ProductBrand>> IBrandRepository.GetAllBrands()
        {
            return await _context
                .Brands
                .Find(brand => true)
                .ToListAsync();
        }

        // ITypesRepository implementation: Get all product types
        async Task<IEnumerable<ProductType>> ITypesRepository.GetAllTypes()
        {
            return await _context
                .Types
                .Find(type => true)
                .ToListAsync();
        }
    }
}
