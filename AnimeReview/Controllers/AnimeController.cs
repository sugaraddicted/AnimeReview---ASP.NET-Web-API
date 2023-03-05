using AnimeReview.Interfaces;
using AnimeReview.Models;
using Microsoft.AspNetCore.Mvc;

namespace AnimeReview.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class AnimeController : Controller
    {
        private readonly IAnimeRepository _animeRepository;
        public AnimeController(IAnimeRepository animeRepository)
        {
            _animeRepository = animeRepository; 
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Anime>))]
        public IActionResult GetAnimes()
        {
            var animes = _animeRepository.GetAnimes();

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
            var anime = _animeRepository.GetAnimeById(animeId);

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
