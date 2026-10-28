using Domain.Models;

namespace Domain.Interfaces;

public interface IAuthorRepository
{
    void AddAuthor(Author author);
    int GetAuthorAmount();
    int GetMinPublishedYearByAuthor(int authorid);
    int GetMaxPublishedYearByAuthor(int authorid);
    List<Author> GetAuthors();
    Author GetAuthor(int id);
    void DeleteAuthor(int id);
    void UpdateAuthor(Author author);
}