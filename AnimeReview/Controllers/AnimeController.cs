using AnimeReview.Dto;
using AnimeReview.Interfaces;
using AnimeReview.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AnimeReview.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class AnimeController : Controller
    {
        private readonly IAnimeRepository _animeRepository;

        private readonly IMapper _mapper;

        public AnimeController(IAnimeRepository animeRepository, IMapper mapper)
        {
            _animeRepository = animeRepository; 
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Anime>))]
        public IActionResult GetAnimes()
        {
            var animes = _mapper.Map<List<AnimeDto>>(_animeRepository.GetAnimes());

            if (!ModelState.IsValid)
                    return BadRequest(ModelState);

            return Ok(animes);  
        }

        [HttpGet("{animeId}")]
        [ProducesResponseType(200, Type = typeof(Anime))]
        [ProducesResponseType(400)]
        public IActionResult GetAnimeById(int animeId)
        {
            if (!_animeRepository.AnimeExists(animeId))
                return NotFound();
            var anime = _mapper.Map<AnimeDto>(_animeRepository.GetAnimeById(animeId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(anime);
        }

        [HttpGet("{animeId}/rating")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]
        public IActionResult GetAnimeRating(int animeId)
        {
            if (!_animeRepository.AnimeExists(animeId))
                return NotFound();

            var rating = _animeRepository.GetAnimeRating(animeId);

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(rating);  
        }
    }
}
