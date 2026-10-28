using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class AuthorRepository : IAuthorRepository
{
    public void AddAuthor(Author author)
    {
        using var conn = DataBase.Connection();
        conn.Open();
        var query = "insert into authors(fullname, country, birthyear)values(@fullname, @country, @birthyear)";
        conn.Execute(query, author);
        System.Console.WriteLine("Author added !!");
    }

    public void DeleteAuthor(int id)
    {
        using var conn = DataBase.Connection();
        conn.Open();
        var query = "delete from authors where id = @id";
        conn.Execute(query, id);
        System.Console.WriteLine("Author deleted !!");
    }

    public Author? GetAuthor(int id)
    {
        using var conn = DataBase.Connection();
        conn.Open();
        var query = "select * from authors where id = @id";
        var auth = conn.QuerySingleOrDefault<Author>(query, new { id });
        return auth;
    }

    public int GetAuthorAmount()
    {
        using var conn = DataBase.Connection();
        conn.Open();
        var query = "select count(*) from authors";
        var count = conn.ExecuteScalar(query);
        return Convert.ToInt32(count);
    }


    public List<Author> GetAuthors()
    {
        using var conn = DataBase.Connection();
        conn.Open();
        var query = "select * from authors";
        var author = conn.Query<Author>(query).ToList();
        return author;
    }

    public int GetMaxPublishedYearByAuthor(int authorid)
    {
        using var conn = DataBase.Connection();
        conn.Open();
        var query = "select max(publishedyear) from book where authorid = @authorid";
        var author = conn.ExecuteScalar(query, authorid);
        return Convert.ToInt32(author);
    }

    public int GetMinPublishedYearByAuthor(int authorid)
    {
        using var conn = DataBase.Connection();
        conn.Open();
        var query = "select min(publishedyear) from book where authorid = @authorid";
        var author = conn.ExecuteScalar<int>(query, authorid);
        return author;
    }


    public void UpdateAuthor(Author author)
    {
        using var conn = DataBase.Connection();
        conn.Open();
        var query = "update authors set fullname = @fullname, country = @country, birthyear = @birthyear where id = @id";
        var auth = conn.QuerySingleOrDefault(query, author);
        if (auth == 0)
        {
            System.Console.WriteLine("Not fiend");
        }
        else
        {
            System.Console.WriteLine("Author updated !!");
        }
    }

}
