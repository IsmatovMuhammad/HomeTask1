using Domain.Models;

namespace Domain.Interfaces;

public interface IBookRepository
{
    void AddBook(Book book);
    int GetBookAmount();
    int GetAmountByPublishedYear(int year);
    int GetAmountByGenre(int genreId);
    List<Book> GetBooks();
    Book GetBook(int id);
    void DeleteBook(int id);
    void UpdateBook(Book book);
}
