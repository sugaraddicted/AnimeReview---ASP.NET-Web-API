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

        bool CreateAnime(int genreId, string authorname, string countryName, Anime anime);

        bool UpdateAnime(int authorId, int genreid, Anime anime);

        bool DeleteAnime(Anime anime);

        bool Save();
    }
}
