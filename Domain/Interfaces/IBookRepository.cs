using Domain.Models;

namespace Domain.Interfaces;

public interface IBookRepository
{
    Task AddBook(Book book);
    Task<int> GetBookAmount();
    Task<int> GetAmountByPublishedYear(int year);
    Task<int> GetAmountByGenre(int genreId);
    Task<List<Book>> GetBooks();
    Task<Book> GetBook(int id);
    Task DeleteBook(int id);
    Task UpdateBook(Book book);
}
