using AutoMapper;
using Loymark.DTO;
using Loymark.Models;

namespace Loymark.Helpers
{
    public class MapperProfile : Profile

    {
        public MapperProfile()
        {
            CreateMap<Actividade, ActividadDTO>()
                .ForMember(dest =>dest.NombreCompleto, opt =>opt.MapFrom(src=>src.IdUsuarioNavigation.Nombre + " "+ src.IdUsuarioNavigation.Apellido))
                .ReverseMap();
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();

        }
    }
}
