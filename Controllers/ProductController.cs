using Microsoft.AspNetCore.Mvc;
using RabbitMqProductsAPI.Models;
using RabbitMqProductsAPI.RabbitMQ;
using RabbitMqProductsAPI.Services;

namespace RabbitMqProductsAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService productService;
    private readonly IRabbitMQProducer rabbitMQProducer;

    public ProductController(IProductService productService, IRabbitMQProducer rabbitMQProducer)
    {
        this.productService = productService;
        this.rabbitMQProducer = rabbitMQProducer;
    }

    [HttpGet("productlist")]
    public IEnumerable<Product> GetProductList()
    {
        return productService.GetProductList();
    }

    [HttpGet("getproductbyid")]
    public Product GetProductById(int id)
    {
        return productService.GetProductById(id);
    }

    [HttpPost("addproduct")]
    public Product AddProduct(Product product)
    {
        var productData = productService.AddProduct(product);
        rabbitMQProducer.SendProductMessage(productData);
        return productData;
    }

    [HttpPut("updateproduct")]
    public Product UpdateProduct(Product product)
    {
        return productService.UpdateProduct(product);
    }

    [HttpDelete("deleteproduct")]
    public bool DeleteProduct(int id)
    {
        return productService.DeleteProduct(id);
    }
}