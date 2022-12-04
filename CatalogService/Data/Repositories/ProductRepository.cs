using CatalogService.Models;

namespace CatalogService.Data.Repositories;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(CatalogContext context):base(context)
    {
    }
}