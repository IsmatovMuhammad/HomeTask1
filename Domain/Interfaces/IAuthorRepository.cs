using Domain.Models;

namespace Domain.Interfaces;

public interface IAuthorRepository
{
    Task AddAuthor(Author author);
    Task<int> GetAuthorAmount();
    Task<int> GetMinPublishedYearByAuthor(int authorid);
    Task<int> GetMaxPublishedYearByAuthor(int authorid);
    Task<List<Author>> GetAuthors();
    Task<Author> GetAuthor(int id);
    Task DeleteAuthor(int id);
    Task UpdateAuthor(Author author);
}