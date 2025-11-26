using MiPrimerAPI.DataAccessLayer.Dtos.Category;
using MiPrimerAPI.DataAccessLayer.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using AutoMapper;


namespace MiPrimerAPI.APIMapper
{
    public class Mappers : Profile
    {
        public Mappers()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryCreateUpdateDto>().ReverseMap();
        }
    }
}
