using AnimeReview.Data;
using AnimeReview.Interfaces;
using AnimeReview.Models;

namespace AnimeReview.Repository
{
    public class AnimeRepository : IAnimeRepository
    {
        private readonly DataContext _context;

        public AnimeRepository(DataContext context)
        {
            _context = context; 
        }

        public ICollection<Anime> GetAnimes()
        {
            return _context.Anime.OrderBy(a => a.Id).ToList();
        }

        public Anime GetAnimeById(int id)
        {
            return _context.Anime.Where(a => a.Id == id).FirstOrDefault();
        }

        public Anime GetAnimeByName(string name)
        {
            return _context.Anime.Where(a => a.Name == name).FirstOrDefault();
        }

        public decimal GetAnimeRating(int animeId)
        {
            var review = _context.Reviews.Where(r => r.Anime.Id == animeId);
            
            if(review.Count() <= 0) return 0;

            return ((decimal)review.Sum(r => r.Rating)) / review.Count();

        }

        public bool AnimeExists(int animeId)
        {
            return _context.Anime.Any(p => p.Id == animeId);
        }

        public bool CreateAnime(int genreId, string authorName, string countryName, Anime anime)
        {
            var animeGenreEntity = _context.Genres.Where(g => g.Id == genreId).FirstOrDefault();

            anime.Author = _context.Authors.Where(a => a.Name == authorName).FirstOrDefault();
            anime.Country = _context.Countries.Where(c => c.Name == countryName).FirstOrDefault();

            var asnimeGenre = new AnimeGenre()
            {
                Genre = animeGenreEntity,
                Anime = anime   
            };

            _context.Add(asnimeGenre);
            _context.Add(anime);

            return Save();
        }

        public bool Save()
        {
            var save = _context.SaveChanges();
            return save > 0 ? true : false;
        }

        public bool UpdateAnime(int authorId, int genreId, Anime anime)
        {
            _context.Update(anime);
            return Save();
        }

        public bool DeleteAnime(Anime anime)
        {
            _context.Remove(anime);
            return Save();
        }
    }
}
