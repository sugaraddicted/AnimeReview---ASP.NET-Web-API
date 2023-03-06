using AnimeReview.Dto;
using AnimeReview.Interfaces;
using AnimeReview.Models;
using AnimeReview.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AnimeReview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CountryController : Controller
    {
        private readonly ICountryRepository _countryRepository; 

        private readonly IMapper _mapper;

        public CountryController(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository; 

            _mapper = mapper;   
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Country>))]
        public IActionResult GetCountries()
        {
            var countries = _mapper.Map<List<CountryDto>>(_countryRepository.GetCountries());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(countries);
        }

        [HttpGet("{countryId}")]
        [ProducesResponseType(200, Type = typeof(Country))]
        [ProducesResponseType(400)]
        public IActionResult GetCountryById(int countryId)
        {
            if (!_countryRepository.CountryExists(countryId))
                return NotFound();
            var country = _mapper.Map<CountryDto>(_countryRepository.GetCountryById(countryId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(country);
        }

        [HttpGet("{countryId}/animes")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Anime>))]
        [ProducesResponseType(400)]
        public IActionResult GetAnimesByCountry(int countryId)
        {
            var animes = _mapper.Map<List<AnimeDto>>(
                _countryRepository.GetAnimesByCountry(countryId));

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(animes);
        }


        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCountry([FromBody] CountryDto countryCreate)
        {
            if (countryCreate == null)
                return BadRequest(ModelState);

            var genre = _countryRepository.GetCountries()
                .Where(c => c.Name.Trim().ToUpper() == countryCreate.Name.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (genre != null)
            {
                ModelState.AddModelError("", "Country already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var countryMap = _mapper.Map<Country>(countryCreate);

            if (!_countryRepository.CreateCountry(countryMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }
    }
}
