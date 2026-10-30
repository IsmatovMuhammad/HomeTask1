using System.ComponentModel.DataAnnotations;
using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class ProductRepository : IProductRepository
{
    public async Task AddProduct(Product product)
    {
        using var conn = AppData.Connection();
        conn.Open();
        var query = "insert into products(name, price, quantity, categoryid)values(@name, @price, @quantity, @categoryid)";
        await conn.ExecuteAsync(query, product);
        System.Console.WriteLine("Product add!!");
    }

    public async Task DeleteProduct(int id)
    {
        using var conn = AppData.Connection();
        conn.Open();
        var query = "delete from products where id = @id";
        await conn.ExecuteAsync(query, id);
        System.Console.WriteLine("Product deleted !!");
    }

    public async Task<int> GetAmountOfProducts()
    {
        using var conn = AppData.Connection();
        conn.Open();
        var query = "select count(*) from products";
        var product = await conn.ExecuteAsync(query);
        return product;
    }

    public async Task<int> GetAmountOfProductsByCategory(int categoryId)
    {
        using var conn = AppData.Connection();
        conn.Open();
        var query = "select count(*) from products where categoryid = @categoryid";
        var product = await conn.ExecuteAsync(query, categoryId);
        return product;
    }

    public async Task<int> GetAveragePriceOfProductByCategory(int categoryId)
    {
        using var conn = AppData.Connection();
        conn.Open();
        var query = "select avg(price) from products where categoryid = @categoryid";
        var product = await conn.ExecuteAsync(query, categoryId);
        return product;
    }


    public async Task<int> GetMaxPriceOfProductByCategory(int categoryId)
    {
        using var conn = AppData.Connection();
        conn.Open();
        var query = "select max(price) from products where categoryid = @categoryid";
        var product = await conn.ExecuteAsync(query, categoryId);
        return product;
    }

    public async Task<int> GetMinPriceOfProductByCategory(int categoryId)
    {
        using var conn = AppData.Connection();
        conn.Open();
        var query = "select min(price) from products where categoryid = @categoryid";
        var product = await conn.ExecuteAsync(query, categoryId);
        return product;
    }


    public async Task<Product> GetProduct(int id)
    {
        using var conn = AppData.Connection();
        conn.Open();
        var query = "Select * from products where id = @id";
        var product = await conn.QuerySingleAsync(query, id);
        return product;
    }

    public async Task<List<Product>> GetProducts()
    {
        using var conn = AppData.Connection();
        conn.Open();
        var query = "select * from products";
        var product = await conn.QueryAsync<Product>(query);
        return product.ToList();
    }

    public async Task<Product> GetProductsByCategory(int categoryId)
    {
        using var conn = AppData.Connection();
        conn.Open();
        var query = "select * from products where categoryid = @categoryid";
        var product = await conn.QuerySingleAsync(query, categoryId);
        return product;
    }

    public async Task<int> GetTotalPriceOfProducts()
    {
        using var conn = AppData.Connection();
        conn.Open();
        var query = "select sum(price) from products";
        var product =  await conn.ExecuteAsync(query);
        return product;
    }

    public async Task UpdateProduct(Product product)
    {
        using var conn = AppData.Connection();
        conn.Open();
        var query = "update products set name = @name, price = @price, quantity = @quantity, categoryid = @categoryid";
        await conn.ExecuteAsync(query, product);
        System.Console.WriteLine("Product updated !!");
    }

}
