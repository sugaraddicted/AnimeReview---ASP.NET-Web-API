using AnimeReview.Data;
using AnimeReview.Interfaces;
using AnimeReview.Models;

namespace AnimeReview.Repository
{
    public class GenreRepository : IGenreRepository
    {
        private readonly DataContext _context;

        public GenreRepository(DataContext context)
        {
            _context = context;
        }

        public bool GenreExists(int id)
        {
            return _context.Genres.Any(x => x.Id == id);    
        }

        public ICollection<Anime> GetAnimeByGenreId(int genreId)
        {
            return _context.AnimeGenres.Where(e => e.GenreId == genreId).Select(a => a.Anime).ToList();
        }

        public Genre GetGenreById(int id)
        {
            return _context.Genres.Where(g => g.Id == id).FirstOrDefault();
        }

        public ICollection<Genre> GetGenres()
        {
            return _context.Genres.ToList();
        }
    }
}
