using AnimeReview.Models;

namespace AnimeReview.Interfaces
{
    public interface IAnimeRepository
    {
        ICollection<Anime> GetAnimes();


    }
}
