using AnimeReview.Data;
using AnimeReview.Interfaces;
using AnimeReview.Models;
using Microsoft.EntityFrameworkCore;

namespace AnimeReview.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly DataContext _context;

        public AuthorRepository(DataContext context)
        {
            _context = context; 
        }

        public ICollection<Anime> GetAuthorsAnimes(int authorId)
        {
            var author = _context.Authors.Include(a => a.Animes).FirstOrDefault(a => a.Id == authorId);
            return author?.Animes.ToList();
        }

        public Author GetAuthorById(int id)
        {
            return _context.Authors.Where(a => a.Id == id).FirstOrDefault();
        }

        public ICollection<Author> GetAuthors()
        {
            return _context.Authors.ToList();
        }

        public bool AuthorExists(int id)
        {
            return _context.Authors.Any(a => a.Id == id);
        }
    }
}
