using AutoMapper;
using BibliotecaAPI.DTO;
using BibliotecaAPI.Models;

namespace BibliotecaAPI.Utils
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AutorDTO, Autor>();
            CreateMap<CategoriaDTO, Categorium>();
            CreateMap<LibroDTO, Libro>();
            CreateMap<UsuarioDTO, Usuario>();
            CreateMap<LibroAutorDTO, LibroAutor>();
            CreateMap<LibroCategoriaDTO, LibroCategorium>();
            CreateMap<Libro, LibroDTO>()
            .ForMember(dest => dest.Categorias, opt => opt.Ignore())
            .ForMember(dest => dest.Autores, opt => opt.Ignore());
        }

    }
}
