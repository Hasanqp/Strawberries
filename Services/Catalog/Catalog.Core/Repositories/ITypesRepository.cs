using Catalog.Core.Entities;

namespace Catalog.Core.Repositories
{
    public interface ITypesRepository
    {
        // To fetch all product types
        Task<IEnumerable<ProductType>> GetAllTypes();
    }
}
