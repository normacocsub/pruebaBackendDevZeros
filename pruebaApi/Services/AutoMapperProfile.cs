using AutoMapper;
using PruebaApi.Models;
using Entity;

namespace PruebaApi.Services
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Library, LibraryOutputModels>();
            CreateMap<LibraryInputModels, Library>();
            CreateMap<Usuario, UsuarioViewModels>();
            CreateMap<UsuarioViewModels, Usuario>();
        }
    }
}
