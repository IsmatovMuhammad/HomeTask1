using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class AuthorRepository : IAuthorRepository
{
    public async Task AddAuthor(Author author)
    {
        using var conn = DataBase.Connection();
        conn.Open();
        var query = "insert into authors(fullname, country, birthyear)values(@fullname, @country, @birthyear)";
        await conn.ExecuteAsync(query, author);
    }

    public async Task DeleteAuthor(int id)
    {
        using var conn = DataBase.Connection();
        conn.Open();
        var query = "delete from authors where id = @id";
        await conn.ExecuteAsync(query, id);
        System.Console.WriteLine("Author deleted !!");
    }

    public Task<Author> GetAuthor(int id)
    {
        using var conn = DataBase.Connection();
        conn.Open();
        var query = "select * from authors where id = @id";
        var auth = conn.QuerySingleAsync<Author>(query, new { id });
        return auth;
    }

    public Task<int> GetAuthorAmount()
    {
        using var conn = DataBase.Connection();
        conn.Open();
        var query = "select count(*) from authors";
        var count = conn.ExecuteAsync(query);
        return count;
    }


    public async Task<List<Author>> GetAuthors()
    {
        using var conn = DataBase.Connection();
        conn.Open();
        var query = "select * from authors";
        var author = await conn.QueryAsync<Author>(query);
        return author.ToList();
    }

    public async Task<int> GetMaxPublishedYearByAuthor(int authorid)
    {
        using var conn = DataBase.Connection();
        conn.Open();
        var query = "select max(publishedyear) from book where authorid = @authorid";
        var author = await conn.ExecuteAsync(query, authorid);
        return author;
    }

    public async Task<int> GetMinPublishedYearByAuthor(int authorid)
    {
        using var conn = DataBase.Connection();
        conn.Open();
        var query = "select min(publishedyear) from book where authorid = @authorid";
        var author = await conn.ExecuteAsync(query, authorid);
        return author;
    }


    public async Task UpdateAuthor(Author author)
    {
        using var conn = DataBase.Connection();
        conn.Open();
        var query = "update authors set fullname = @fullname, country = @country, birthyear = @birthyear where id = @id";
        var auth = await conn.ExecuteAsync(query, author);
    }

}
