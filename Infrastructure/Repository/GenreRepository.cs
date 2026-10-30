using System.Data;
using System.Diagnostics.Contracts;
using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class GenreRepository : IGenreRepository
{
    public async Task AddGenre(Genre genre)
    {
        using var conn = DataBase.Connection();
        conn.Open();
        var query = "insert into genres(name)values(@genres)";
        await conn.ExecuteAsync(query, genre);
        System.Console.WriteLine("Genre added !!");
    }

    public async Task Deletegenre(int id)
    {
        using var conn = DataBase.Connection();
        conn.Open();
        var query = "delete from genres where id = @id";
        await conn.ExecuteAsync(query, id);
        System.Console.WriteLine("Genre deleted !!");
    }

    public async Task<Genre> GetGenre(int id)
    {
        using var conn = DataBase.Connection();
        conn.Open();
        var query = "Select * from genres where id = @id";
        var genre = await conn.QuerySingleAsync<Genre>(query, id);
        return genre;
    }

    public async Task<int> GetGenreAmount()
    {
        using var conn = DataBase.Connection();
        conn.Open();
        var query = "select count(*) from genres";
        var count = await conn.ExecuteAsync(query);
        return Convert.ToInt32(count);
    }

    public async Task<List<Genre>> GetGenres()
    {
        using var conn = DataBase.Connection();
        conn.Open();
        var query = "Select * from genres";
        var genre = await conn.QueryAsync<Genre>(query);
        return genre.ToList();
    }

    public async Task<int> GetMaxPublishedYearByGenre(int genreid)
    {
        using var conn = DataBase.Connection();
        conn.Open();
        var query = "select max(publishedyear) from book where genreid = @genreid";
        var author = await conn.ExecuteAsync(query, genreid);
        return author;
    }

    public async Task<int> GetMinPublishedYearByGenre(int genreid)
    {
        using var conn = DataBase.Connection();
        conn.Open();
        var query = "select min(publishedyear) from book where genreid = @genreid";
        var author = await conn.ExecuteAsync(query, genreid);
        return author;
    }


    public async Task UpdateGenre(Genre genre)
    {
        using var conn = DataBase.Connection();
        conn.Open();
        var query = "update genres set name = @name where id = @id";
        conn.Execute(query, genre);
    }

}
