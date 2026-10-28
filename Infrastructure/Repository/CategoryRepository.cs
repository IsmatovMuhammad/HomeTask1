using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class CategoryRepository : ICategoryRepository
{
    public void AddCategory(Category category)
    {
        using var conn = AppData.Connection();
        conn.Open();
        var query = "insert into categories(name)values(@name)";
        conn.Execute(query, category);
    }

    public void DeleteCategory(int id)
    {
        using var conn = AppData.Connection();
        conn.Open();
        var query = "delete from categories where id = @id";
        conn.Execute(query, id);
    }

    public int GetAmountOfCategories()
    {
        using var conn = AppData.Connection();
        conn.Open();
        var query = "select count(*) from categories";
        var category = conn.ExecuteScalar<int>(query);
        return category;
    }


    public List<Category> GetCategories()
    {
        using var conn = AppData.Connection();
        conn.Open();
        var query = "select * from categories";
        var category = conn.Query<Category>(query).ToList();
        return category;
    }

    public Category? GetCategory(int id)
    {
        using var conn = AppData.Connection();
        conn.Open();
        var query = "select * from categories where id = @id";
        var category = conn.QuerySingleOrDefault<Category>(query);
        return category;
    }

    public void UpdateCategory(Category category)
    {
        using var conn = DataBase.Connection();
        conn.Open();
        var query = "update categories set name = @name where id = @id";
        conn.Execute(query, category);
    }

}
