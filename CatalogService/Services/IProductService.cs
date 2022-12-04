using CatalogService.Models;

namespace CatalogService.Services;

public interface IProductService
{
    IEnumerable<Product> GetProducts();
    Product GetProductById(int id);
    void UpdateProduct(int id ,Product product);
    void SaveProduct(Product product);
    void DeleteProduct(Product product);
    bool ProductExists(int id);

}