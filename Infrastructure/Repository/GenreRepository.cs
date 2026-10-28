using System.Data;
using System.Diagnostics.Contracts;
using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class GenreRepository : IGenreRepository
{
    public void AddGenre(Genre genre)
    {
        using var conn = DataBase.Connection();
        conn.Open();
        var query = "insert into genres(name)values(@genres)";
        conn.Execute(query, genre);
        System.Console.WriteLine("Genre added !!");
    }

    public void Deletegenre(int id)
    {
        using var conn = DataBase.Connection();
        conn.Open();
        var query = "delete from genres where id = @id";
        conn.Execute(query, id);
        System.Console.WriteLine("Genre deleted !!");
    }

    public Genre? GetGenre(int id)
    {
        using var conn = DataBase.Connection();
        conn.Open();
        var query = "Select * from genres where id = @id";
        var genre = conn.QuerySingleOrDefault<Genre>(query, id);
        return genre;
    }

    public int GetGenreAmount()
    {
        using var conn = DataBase.Connection();
        conn.Open();
        var query = "select count(*) from genres";
        var count = conn.ExecuteScalar(query);
        return Convert.ToInt32(count);
    }

    public List<Genre> GetGenres()
    {
        using var conn = DataBase.Connection();
        conn.Open();
        var query = "Select * from genres";
        var genre = conn.Query<Genre>(query).ToList();
        return genre;
    }

    public int GetMaxPublishedYearByGenre(int genreid)
    {
        using var conn = DataBase.Connection();
        conn.Open();
        var query = "select max(publishedyear) from book where genreid = @genreid";
        var author = conn.ExecuteScalar<int>(query, genreid);
        return author;
    }

    public int GetMinPublishedYearByGenre(int genreid)
    {
        using var conn = DataBase.Connection();
        conn.Open();
        var query = "select min(publishedyear) from book where genreid = @genreid";
        var author = conn.ExecuteScalar<int>(query, genreid);
        return author;
    }


    public void UpdateGenre(Genre genre)
    {
        using var conn = DataBase.Connection();
        conn.Open();
        var query = "update genres set name = @name where id = @id";
        conn.Execute(query, genre);
    }

}
