using Catalog.Core.Entities;
using MongoDB.Driver;
using System.Text.Json;

namespace Catalog.Infrastructure.Data
{
    public static class TypeContextSeed
    {
        public static void SeedData(IMongoCollection<ProductType> typeCollection)
        {
            // Check if the product types collection already contains any data
            bool checkTypes = typeCollection.Find(b => true).Any();

            // Build the path to the JSON seed data file for product types
            //string path = Path.Combine("Data", "SeedData", "types.json");
            var basePath = AppContext.BaseDirectory;
            var path = Path.Combine(basePath, "Data", "SeedData", "types.json");
            // Only seed data if the collection is empty (no existing types)
            if (!checkTypes)
            {
                // Read all text content from the types JSON file
                var typesData = File.ReadAllText(path);
                // Alternative hardcoded path (commented out for reference):
                //var typesData = File.ReadAllText("../Catalog.Infrastructure/Data/SeedData/types.json");

                // Deserialize JSON data into a List of ProductType objects
                var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                // Check if deserialization was successful and the types list is not null
                if (types != null)
                {
                    // Insert each product type into the MongoDB collection asynchronously
                    foreach (var item in types)
                    {
                        typeCollection.InsertOneAsync(item);
                    }
                }
            }
        }
    }
}
