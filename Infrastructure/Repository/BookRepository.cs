using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Dapper;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Repository;

public class BookRepository : IBookRepository
{
    public void AddBook(Book book)
    {
        using var conn = DataBase.Connection();
        conn.Open();
        var query = "insert into book(title, publishedyear, totalcopies)values(@title, @publishedyear, @totalcopies)";
        conn.Execute(query, new{book.Title, book.PublishedYear, book.TotalCopies});
        System.Console.WriteLine("Book Added !!");
    }

    public void DeleteBook(int id)
    {
        using var conn = DataBase.Connection();
        conn.Open();
        var query = "delete from book where id = @id";
        conn.Execute(query, new { id });
        System.Console.WriteLine("Book deleted !!");
    }

    public int GetAmountByGenre(int genreId)
    {
        using var conn = DataBase.Connection();
        conn.Open();
        var query = "select count(*) from book where genreid = @genreid";
        var genre = conn.ExecuteScalar<int>(query, genreId);
        return genre;
    }

    public int GetAmountByPublishedYear(int year)
    {
        using var conn = DataBase.Connection();
        conn.Open();
        var query = "select count(*) from book where publishedyear = @year";
        var genre = conn.ExecuteScalar<int>(query, year);
        return genre;
    }


    public Book? GetBook(int id)
    {
        using var conn = DataBase.Connection();
        conn.Open();
        var query = "select * from book where id = @id";
        var book = conn.QuerySingleOrDefault<Book>(query, new { id });
        return book;
    }

    public int GetBookAmount()
    {
        using var conn = DataBase.Connection();
        conn.Open();
        var query = "select count(*) from book";
        var count = conn.ExecuteScalar(query);
        return Convert.ToInt32(count);
    }


    public List<Book> GetBooks()
    {
        using var conn = DataBase.Connection();
        conn.Open();
        var query = "Select * from book";
        var book = conn.Query<Book>(query).ToList();
        return book;
    }

    public void UpdateBook(Book book)
    {
        using var conn = DataBase.Connection();
        conn.Open();
        var query = "update book set title = @title, publishedyear = @publishedyear, totalcopies = @totalcopies where id = @id";
        conn.Execute(query, book);
        System.Console.WriteLine("Book updated !!");
    }

}
