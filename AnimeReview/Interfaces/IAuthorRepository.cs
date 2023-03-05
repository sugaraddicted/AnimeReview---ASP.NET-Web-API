using AnimeReview.Models;

namespace AnimeReview.Interfaces
{
    public interface IAuthorRepository
    {
        ICollection<Author> GetAuthors();

        Author GetAuthorById(int id);

        ICollection<Anime> GetAuthorsAnimes(int authorsId); 

        bool AuthorExists(int id);

    }
}
