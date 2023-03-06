using AnimeReview.Dto;
using AnimeReview.Models;
using AutoMapper;

namespace AnimeReview.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Anime, AnimeDto>();

            CreateMap<Genre, GenreDto>();

            CreateMap<GenreDto, Genre>();

            CreateMap<Country, CountryDto>();

            CreateMap<Author, AuthorDto>();

            CreateMap<Review, ReviewDto>();
            
            CreateMap<Reviewer, ReviewerDto>();

        }
    }
}
