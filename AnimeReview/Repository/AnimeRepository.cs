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
    }
}
