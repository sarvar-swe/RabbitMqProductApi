using RabbitMqProductsAPI.Models;

namespace RabbitMqProductsAPI.Services;

public interface IProductService
{
    public IEnumerable<Product> GetProductList();
    public Product GetProductById(int id);
    public Product AddProduct(Product product);
    public Product UpdateProduct(Product product);
    public bool DeleteProduct(int id);
}