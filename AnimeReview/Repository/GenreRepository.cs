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

        public bool CreateGenre(Genre genre)
        {
            _context.Add(genre);
            return Save();
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

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateGenre(Genre genre)
        {
            _context.Update(genre);
            return Save();
        }
    }
}
