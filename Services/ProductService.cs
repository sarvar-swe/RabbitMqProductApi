using RabbitMqProductsAPI.Data;
using RabbitMqProductsAPI.Models;

namespace RabbitMqProductsAPI.Services;

public class ProductService : IProductService
{
    private readonly DbContextClass dbContext;

    public ProductService(DbContextClass dbContext)
    {
        this.dbContext = dbContext;
    }

    public IEnumerable<Product> GetProductList()
    {
        return dbContext.Products.ToList();
    }
    public Product GetProductById(int id)
    {
        return dbContext.Products.Where(x => x.ProductId == id).FirstOrDefault();
    }
    public Product AddProduct(Product product)
    {
        var result = dbContext.Products.Add(product);
        dbContext.SaveChanges();
        return result.Entity;
    }
    public Product UpdateProduct(Product product)
    {
        var result = dbContext.Products.Update(product);
        dbContext.SaveChanges();
        return result.Entity;
    }
    public bool DeleteProduct(int id)
    {
        var filterData = dbContext.Products.Where(x => x.ProductId == id).FirstOrDefault();
        var result = dbContext.Products.Remove(filterData);
        dbContext.SaveChanges();
        return result != null ? true : false;
    }
}