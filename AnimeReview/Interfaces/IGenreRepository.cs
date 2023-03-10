using AnimeReview.Models;

namespace AnimeReview.Interfaces
{
    public interface IGenreRepository
    {
        ICollection<Genre> GetGenres();

        Genre GetGenreById(int id);

        ICollection<Anime> GetAnimeByGenreId(int genreId);

        bool GenreExists(int id);

        bool CreateGenre(Genre genre);

        bool Save();

        bool UpdateGenre(Genre genre);

        bool DeleteGenre(Genre genre);
    }
}
