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
    public class AnimeController : Controller
    {
        private readonly IAnimeRepository _animeRepository;
        private readonly IReviewRepository _reviewRepository;

        private readonly IMapper _mapper;

        public AnimeController(IAnimeRepository animeRepository, IReviewRepository reviewRepository, IMapper mapper)
        {
            _animeRepository = animeRepository; 
            _reviewRepository = reviewRepository;
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

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateAnime([FromQuery] int genreId, [FromQuery] string authorName, [FromQuery] string countryName, [FromBody] AnimeDto animeCreate)
        {
            if (animeCreate == null)
                return BadRequest(ModelState);

            var animes = _animeRepository.GetAnimes()
                .Where(a => a.Name.Trim().ToUpper() == animeCreate.Name.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (animes != null)
            {
                ModelState.AddModelError("", "Anime already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var animeMap = _mapper.Map<Anime>(animeCreate);

            if (!_animeRepository.CreateAnime(genreId, authorName,countryName, animeMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{animeId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateAnime(int animeId,
            [FromQuery] int authorId,
            [FromQuery] int genreId, 
            [FromBody] AnimeDto updatedAnime)
        {
            if (updatedAnime == null)
                return BadRequest(ModelState);

            if (animeId != updatedAnime.Id)
                return BadRequest(ModelState);

            if (!_animeRepository.AnimeExists(animeId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var animeMap = _mapper.Map<Anime>(updatedAnime);

            if (!_animeRepository.UpdateAnime(authorId, genreId, animeMap))
            {
                ModelState.AddModelError("", "Something went wrong updating the anime");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully Updated");
        }

        [HttpDelete("{animeId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteAnime(int animeId)
        {
            if (!_animeRepository.AnimeExists(animeId))
            {
                return NotFound();
            }

            var reviewsToDelete = _reviewRepository.GetReviewsOfAnime(animeId);

            if (!_reviewRepository.DeleteReviews(reviewsToDelete.ToList()))
            {
                ModelState.AddModelError("", "Something went wrong deleting anime");
            }

            var animeToDelete = _animeRepository.GetAnimeById(animeId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_animeRepository.DeleteAnime(animeToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting anime");
            }

            return Ok("Successfully Deleted");
        }
    }
}
