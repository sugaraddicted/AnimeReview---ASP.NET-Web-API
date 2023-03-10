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
    public class AuthorController : Controller
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public AuthorController(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Author>))]
        public IActionResult GetAuthors()
        {
            var authors = _mapper.Map<List<AuthorDto>>(_authorRepository.GetAuthors());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(authors);
        }

        [HttpGet("{authorId}")]
        [ProducesResponseType(200, Type = typeof(Author))]
        [ProducesResponseType(400)]
        public IActionResult GetAuthorById(int authorId)
        {
            if (!_authorRepository.AuthorExists(authorId))
                return NotFound();
            var author = _mapper.Map<AuthorDto>(_authorRepository.GetAuthorById(authorId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(author);
        }

        [HttpGet("{authorId}/animes")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Anime>))]
        [ProducesResponseType(400)]
        public IActionResult GetAuthorsAnimes(int authorId)
        {
            var animes = _mapper.Map<List<AnimeDto>>(
                _authorRepository.GetAuthorsAnimes(authorId));

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(animes);
        }


        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateAuthor([FromBody] AuthorDto authorCreate)
        {
            if (authorCreate == null)
                return BadRequest(ModelState);

            var author = _authorRepository.GetAuthors()
                .Where(c => c.Name.Trim().ToUpper() == authorCreate.Name.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (author != null)
            {
                ModelState.AddModelError("", "Author already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var authorMap = _mapper.Map<Author>(authorCreate);

            if (!_authorRepository.CreateAuthor(authorMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{authorId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateAuthor(int authorId, [FromBody] AuthorDto updatedAuthor)
        {
            if (updatedAuthor == null)
                return BadRequest(ModelState);

            if (authorId != updatedAuthor.Id)
                return BadRequest(ModelState);

            if (!_authorRepository.AuthorExists(authorId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var authorMap = _mapper.Map<Author>(updatedAuthor);

            if (!_authorRepository.UpdateAuthor(authorMap))
            {
                ModelState.AddModelError("", "Something went wrong updating the author");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully Updated");
        }

    }
}
