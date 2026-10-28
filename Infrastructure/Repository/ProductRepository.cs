using System.ComponentModel.DataAnnotations;
using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class ProductRepository : IProductRepository
{
    public void AddProduct(Product product)
    {
        using var conn = AppData.Connection();
        conn.Open();
        var query = "insert into products(name, price, quantity, categoryid)values(@name, @price, @quantity, @categoryid)";
        conn.Execute(query, product);
        System.Console.WriteLine("Product add!!");
    }

    public void DeleteProduct(int id)
    {
        using var conn = AppData.Connection();
        conn.Open();
        var query = "delete from products where id = @id";
        conn.Execute(query, id);
        System.Console.WriteLine("Product deleted !!");
    }

    public int GetAmountOfProducts()
    {
        using var conn = AppData.Connection();
        conn.Open();
        var query = "select count(*) from products";
        var product = conn.ExecuteScalar<int>(query);
        return product;
    }

    public int GetAmountOfProductsByCategory(int categoryId)
    {
        using var conn = AppData.Connection();
        conn.Open();
        var query = "select count(*) from products where categoryid = @categoryid";
        var product = conn.ExecuteScalar<int>(query, categoryId);
        return product;
    }

    public int GetAveragePriceOfProductByCategory(int categoryId)
    {
        using var conn = AppData.Connection();
        conn.Open();
        var query = "select avg(price) from products where categoryid = @categoryid";
        var product = conn.ExecuteScalar<int>(query, categoryId);
        return product;
    }


    public int GetMaxPriceOfProductByCategory(int categoryId)
    {
        using var conn = AppData.Connection();
        conn.Open();
        var query = "select max(price) from products where categoryid = @categoryid";
        var product = conn.ExecuteScalar<int>(query, categoryId);
        return product;
    }

    public int GetMinPriceOfProductByCategory(int categoryId)
    {
        using var conn = AppData.Connection();
        conn.Open();
        var query = "select min(price) from products where categoryid = @categoryid";
        var product = conn.ExecuteScalar<int>(query, categoryId);
        return product;
    }


    public Product? GetProduct(int id)
    {
        using var conn = AppData.Connection();
        conn.Open();
        var query = "Select * from products where id = @id";
        var product = conn.QuerySingleOrDefault(query, id);
        return product;
    }

    public List<Product> GetProducts()
    {
        using var conn = AppData.Connection();
        conn.Open();
        var query = "select * from products";
        var product = conn.Query<Product>(query).ToList();
        return product;
    }

    public Product? GetProductsByCategory(int categoryId)
    {
        using var conn = AppData.Connection();
        conn.Open();
        var query = "select * from products where categoryid = @categoryid";
        var product = conn.QuerySingleOrDefault(query, categoryId);
        return product;
    }

    public int GetTotalPriceOfProducts()
    {
        using var conn = AppData.Connection();
        conn.Open();
        var query = "select sum(price) from products";
        var product = conn.ExecuteScalar<int>(query);
        return product;
    }

    public void UpdateProduct(Product product)
    {
        using var conn = AppData.Connection();
        conn.Open();
        var query = "update products set name = @name, price = @price, quantity = @quantity, categoryid = @categoryid";
        conn.Execute(query, product);
        System.Console.WriteLine("Product updated !!");
    }

}
