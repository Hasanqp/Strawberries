using Catalog.Core.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data
{
    public class CatalogContext : ICatalogContext
    {
        // MongoDB collections for Products, Brands, and Types
        public IMongoCollection<Product> Products { get; }

        public IMongoCollection<ProductBrand> Brands { get; }

        public IMongoCollection<ProductType> Types { get; }

        // Constructor that initializes the database connection and collections
        public CatalogContext(IConfiguration configuration)
        {

            // Create MongoDB client using connection string from configuration
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            // Get database instance using database name from configuration
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            // Initialize Brands collection with the specified collection name from configuration
            Brands = database.GetCollection<ProductBrand>(configuration.GetValue<string>("DatabaseSettings:BrandsCollection"));

            // Initialize Types collection with the specified collection name from configuration
            Types = database.GetCollection<ProductType>(configuration.GetValue<string>("DatabaseSettings:TypesCollection"));

            // Initialize Products collection with the specified collection name from configuration
            Products = database.GetCollection<Product>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));

            // Seed initial data for Brands collection if empty
            BrandContextSeed.SeedData(Brands);

            // Seed initial data for Types collection if empty
            TypeContextSeed.SeedData(Types);

            // Seed initial data for Products collection if empty
            CatalogContextSeed.SeedData(Products);
        }
    }
}
