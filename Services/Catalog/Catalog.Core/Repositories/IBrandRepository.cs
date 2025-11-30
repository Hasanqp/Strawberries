using Catalog.Core.Entities;

namespace Catalog.Core.Repositories
{
    public interface IBrandRepository
    {
        // To fetch all brands
        Task<IEnumerable<ProductBrand>> GetAllBrands();
    }
}
