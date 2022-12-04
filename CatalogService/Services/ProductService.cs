using CatalogService.Data.Repositories;
using CatalogService.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly ILogger<ProductService> _logger;

    public ProductService(IProductRepository productRepository, ILogger<ProductService> logger)
    {
        _productRepository = productRepository;
        _logger = logger;
    }
    
    public IEnumerable<Product> GetProducts()
    {
        try
        {
            return _productRepository.GetAll();
        }
        catch (Exception e)
        {
            _logger.LogError("GetProducts exception, exMessage:{ExceptionMessage}", e.Message);
            throw;
        }
    }

    public Product GetProductById(int id)
    {
        try
        {
            return _productRepository.GetById(id) ?? throw new InvalidOperationException();
        }
        catch (Exception e)
        {
            _logger.LogError("GetProductById exception, exMessage:{ExceptionMessage}", e.Message);
            throw;
        }
    }

    public void UpdateProduct(int id, Product product)
    {
        try
        {
            _productRepository.Update(product);
        }
        catch (DbUpdateConcurrencyException e)
        {
            _logger.LogError("UpdateProduct exception, exMessage:{ExceptionMessage}", e.Message);
        }
    }

    public void SaveProduct(Product product)
    {
        try
        {
            _productRepository.Add(product);
        }
        catch (Exception e)
        {
            _logger.LogError("SaveProduct exception, exMessage:{ExceptionMessage}", e.Message);
            throw;
        }
    }

    public void DeleteProduct(Product product)
    {
        try
        {
            _productRepository.Remove(product);
        }
        catch (Exception e)
        {
            _logger.LogError("DeleteProduct exception, exMessage:{ExceptionMessage}", e.Message);
            throw;
        }
    }
    
    public bool ProductExists(int id)
    {
        return _productRepository.Find(e => e.Id == id).Any();
    }
}