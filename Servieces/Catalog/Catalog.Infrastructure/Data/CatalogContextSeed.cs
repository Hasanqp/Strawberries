using Catalog.Core.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Data
{
    public static class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            // Check if the products collection already contains any data
            bool checkProducts = productCollection.Find(b => true).Any();

            // Build the path to the JSON seed data file for products
            string path = Path.Combine("Data", "SeedData", "products.json");

            // Only seed data if the collection is empty (no existing products)
            if (!checkProducts)
            {
                // Read all text content from the products JSON file
                var productsData = File.ReadAllText(path);
                // Alternative hardcoded path (commented out for reference):
                //var productsData = File.ReadAllText("../Catalog.Infrastructure/Data/SeedData/products.json");

                // Deserialize JSON data into a List of Product objects
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                // Check if deserialization was successful and the products list is not null
                if (products != null)
                {
                    // Insert each product into the MongoDB collection asynchronously
                    foreach (var item in products)
                    {
                        productCollection.InsertOneAsync(item);
                    }
                }
            }
        }

    }
}
