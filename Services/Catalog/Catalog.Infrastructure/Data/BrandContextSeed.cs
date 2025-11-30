using Catalog.Core.Entities;
using MongoDB.Driver;
using System.Text.Json;

namespace Catalog.Infrastructure.Data
{
    public static class BrandContextSeed 
    {
        public static void SeedData(IMongoCollection<ProductBrand> brandCollection)
        {
            // Check if brands collection already contains any data
            bool checkBrands = brandCollection.Find(b => true).Any();

            // Build the path to the JSON seed data file dynamically
            var basePath = AppContext.BaseDirectory;
            var path = Path.Combine(basePath, "Data", "SeedData", "brands.json");

            // Only seed data if the collection is empty
            if (!checkBrands)
            {
                // Read all text from the JSON file
                var brandsData = File.ReadAllText(path);

                // Alternative hardcoded path (commented out):
                //var brandsData = File.ReadAllText("../Catalog.Infrastructure/Data/SeedData/brands.json");

                // Deserialize JSON data into List<ProductBrand> objects
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                // Check if deserialization was successful and brands list is not null
                if (brands != null)
                {
                    // Insert each brand into the MongoDB collection asynchronously
                    foreach (var item in brands)
                    {
                        brandCollection.InsertOneAsync(item);
                    }
                }
            }
        }
    }
}
