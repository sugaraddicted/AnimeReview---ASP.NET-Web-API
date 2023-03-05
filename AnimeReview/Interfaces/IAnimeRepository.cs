using AnimeReview.Models;

namespace AnimeReview.Interfaces
{
    public interface IAnimeRepository
    {
        ICollection<Anime> GetAnimes();

        Anime GetAnimeById(int id);

        Anime GetAnimeByName(string name);

        decimal GetAnimeRating(int animeId);

        bool AnimeExists(int animeId);  
    }
}
