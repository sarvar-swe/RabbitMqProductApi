using Microsoft.EntityFrameworkCore;
using RabbitMqProductsAPI.Models;

namespace RabbitMqProductsAPI.Data;

public class DbContextClass : DbContext
{
    private readonly IConfiguration configuration;

    public DbContextClass(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
    }

    public DbSet<Product> Products { get; set; }
}