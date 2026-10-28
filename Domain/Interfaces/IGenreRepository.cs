using System.ComponentModel;
using Domain.Models;

namespace Domain.Interfaces;

public interface IGenreRepository
{
    void AddGenre(Genre genre);
    int GetGenreAmount();
    int GetMinPublishedYearByGenre(int genreid);
    int GetMaxPublishedYearByGenre(int genreid);
    List<Genre> GetGenres();
    Genre GetGenre(int id);
    void Deletegenre(int id);
    void UpdateGenre(Genre genre);
}
