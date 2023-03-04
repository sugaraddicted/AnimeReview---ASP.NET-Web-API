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
    }
}
