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
            CreateMap<AnimeDto, Anime>();

            CreateMap<Genre, GenreDto>();
            CreateMap<GenreDto, Genre>();

            CreateMap<Country, CountryDto>();
            CreateMap<CountryDto, Country>();

            CreateMap<Author, AuthorDto>();
            CreateMap<AuthorDto, Author>();

            CreateMap<Review, ReviewDto>();
            CreateMap<ReviewDto, Review>();
            
            CreateMap<Reviewer, ReviewerDto>();
            CreateMap<ReviewerDto, Reviewer>();
        }
    }
}
