using MiPrimerAPI.DataAccessLayer.Dtos.Category;
using MiPrimerAPI.DataAccessLayer.Dtos.Movie;
using MiPrimerAPI.DataAccessLayer.Models;
using AutoMapper;

namespace MiPrimerAPI.APIMapper
{
    public class Mappers : Profile
    {
        public Mappers()
        {
            // Category
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryCreateUpdateDto>().ReverseMap();

            // Movie
            CreateMap<Movie, MovieDto>().ReverseMap();
            CreateMap<Movie, MovieCreateUpdateDto>().ReverseMap();
        }
    }
}
