using AnimeReview.Models;

namespace AnimeReview.Interfaces
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountries();

        Country GetCountryById(int id);

        ICollection<Anime> GetAnimesByCountry(int countryId);

        bool CountryExists(int id);

        bool CreateCountry(Country country);

        bool Save();
    }
}
