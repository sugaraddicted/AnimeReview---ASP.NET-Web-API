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
    }
}
