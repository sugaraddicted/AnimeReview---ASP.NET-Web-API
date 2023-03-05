using AnimeReview.Data;
using AnimeReview.Interfaces;
using AnimeReview.Models;
using AutoMapper;

namespace AnimeReview.Repository
{ 

    public class CountryRepository : ICountryRepository
    {
        private readonly DataContext _context;

        public CountryRepository(DataContext context)
        {
            _context = context;
        }

        public bool CountryExists(int id)
        {
            return _context.Countries.Any(c => c.Id == id);  
        }

        public ICollection<Anime> GetAnimesByCountry(int countryId)
        {
            return _context.Anime.Where(a => a.Country.Id == countryId).ToList();
        }

        public ICollection<Country> GetCountries()
        {
            return _context.Countries.ToList();
        }

        public Country GetCountryById(int id)
        {
            return _context.Countries.Where(c => c.Id == id).FirstOrDefault();
        }
    }
}
