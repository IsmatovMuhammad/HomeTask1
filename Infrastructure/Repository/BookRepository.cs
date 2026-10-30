using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Dapper;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Repository;

public class BookRepository : IBookRepository
{
    public async Task AddBook(Book book)
    {
        using var conn = DataBase.Connection();
        conn.Open();
        var query = "insert into book(title, publishedyear, totalcopies)values(@title, @publishedyear, @totalcopies)";
        await conn.ExecuteAsync(query, new{book.Title, book.PublishedYear, book.TotalCopies});
        System.Console.WriteLine("Book Added !!");
    }

    public async Task DeleteBook(int id)
    {
        using var conn = DataBase.Connection();
        conn.Open();
        var query = "delete from book where id = @id";
        await conn.ExecuteAsync(query, new { id });
        System.Console.WriteLine("Book deleted !!");
    }

    public async Task<int> GetAmountByGenre(int genreId)
    {
        using var conn = DataBase.Connection();
        conn.Open();
        var query = "select count(*) from book where genreid = @genreid";
        var genre = await conn.ExecuteAsync(query, genreId);
        return genre;
    }

    public async Task<int> GetAmountByPublishedYear(int year)
    {
        using var conn = DataBase.Connection();
        conn.Open();
        var query = "select count(*) from book where publishedyear = @year";
        var genre = await conn.ExecuteAsync(query, year);
        return genre;
    }


    public async Task<Book> GetBook(int id)
    {
        using var conn = DataBase.Connection();
        conn.Open();
        var query = "select * from book where id = @id";
        var book = await conn.QuerySingleAsync<Book>(query, new { id });
        return book;
    }

    public async Task<int> GetBookAmount()
    {
        using var conn = DataBase.Connection();
        conn.Open();
        var query = "select count(*) from book";
        var count = await conn.ExecuteAsync(query);
        return Convert.ToInt32(count);
    }


    public async Task<List<Book>> GetBooks()
    {
        using var conn = DataBase.Connection();
        conn.Open();
        var query = "Select * from book";
        var book = await conn.QueryAsync<Book>(query);
        return book.ToList();
    }

    public async Task UpdateBook(Book book)
    {
        using var conn = DataBase.Connection();
        conn.Open();
        var query = "update book set title = @title, publishedyear = @publishedyear, totalcopies = @totalcopies where id = @id";
        await conn.ExecuteAsync(query, book);
        System.Console.WriteLine("Book updated !!");
    }

}
