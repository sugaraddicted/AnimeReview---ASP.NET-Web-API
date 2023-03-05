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

            CreateMap<Country, CountryDto>();

            CreateMap<Author, AuthorDto>();
        }
    }
}
