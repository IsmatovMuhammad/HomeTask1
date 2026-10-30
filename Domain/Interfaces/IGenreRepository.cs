using System.ComponentModel;
using Domain.Models;

namespace Domain.Interfaces;

public interface IGenreRepository
{
    Task AddGenre(Genre genre);
    Task<int> GetGenreAmount();
    Task<int> GetMinPublishedYearByGenre(int genreid);
    Task<int> GetMaxPublishedYearByGenre(int genreid);
    Task<List<Genre>> GetGenres();
    Task<Genre> GetGenre(int id);
    Task Deletegenre(int id);
    Task UpdateGenre(Genre genre);
}
