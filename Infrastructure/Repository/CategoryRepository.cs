using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class CategoryRepository : ICategoryRepository
{
    public async Task AddCategory(Category category)
    {
        using var conn = AppData.Connection();
        conn.Open();
        var query = "insert into categories(name)values(@name)";
        await conn.ExecuteAsync(query, category);
    }

    public async Task DeleteCategory(int id)
    {
        using var conn = AppData.Connection();
        conn.Open();
        var query = "delete from categories where id = @id";
        await conn.ExecuteAsync(query, id);
    }

    public async Task<int> GetAmountOfCategories()
    {
        using var conn = AppData.Connection();
        conn.Open();
        var query = "select count(*) from categories";
        var category = await conn.ExecuteAsync(query);
        return category;
    }


    public async Task<List<Category>> GetCategories()
    {
        using var conn = AppData.Connection();
        conn.Open();
        var query = "select * from categories";
        var category = await conn.QueryAsync<Category>(query);
        return category.ToList();
    }

    public async Task<Category> GetCategory(int id)
    {
        using var conn = AppData.Connection();
        conn.Open();
        var query = "select * from categories where id = @id";
        var category = await conn.QuerySingleAsync<Category>(query);
        return category;
    }

    public async Task UpdateCategory(Category category)
    {
        using var conn = DataBase.Connection();
        conn.Open();
        var query = "update categories set name = @name where id = @id";
        await conn.ExecuteAsync(query, category);
    }

}
