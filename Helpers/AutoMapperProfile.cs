namespace Cadeteria;
using AutoMapper;
using Cadeteria.DTOs;
using Cadeteria.Models;

public class AutoMapperProfile : AutoMapper.Profile
{
    public AutoMapperProfile()
    {

        // User -> AuthenticateResponse
        CreateMap<User, AuthenticateResponse>();


        // RegisterRequest -> User
        CreateMap<RegisterRequest, User>();


        // UpdateRequest -> User
        CreateMap<UpdateRequest, User>()
            .ForAllMembers(x => x.Condition(
                (src, dest, prop) =>
                {
                    // ignore null & empty string properties
                    if (prop == null) return false;
                    if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                    return true;
                }
            ));

        CreateMap<User, UserDTO>();
        CreateMap<Models.Profile, ProfileDTO>();
        CreateMap<Rol, RolDTO>();

        CreateMap<Articulo, ArticuloDTO>().ReverseMap();
        CreateMap<Articulo, ArticuloCreateDTO>().ReverseMap();

        CreateMap<Archivo, ArchivoCreateDTO>().ReverseMap(); ;
        CreateMap<Archivo, ArchivoDTO>().ReverseMap(); ;

        CreateMap<ArchivoPerfil, ArchivoDTO>().ReverseMap(); ;
        CreateMap<ArchivoPerfil, ArchivoCreateDTO>().ReverseMap(); ;

        CreateMap<Categoria, CategoriaDTO>().ReverseMap();

        CreateMap<ArticuloCategoria, ArticuloCategoriaDTO>()
        .ForPath(x => x.Articulo.archivos, op => op.MapFrom(x => x.Articulo.archivos))
        .ForMember(x => x.Articulo, op => op.MapFrom(x => x.Articulo))
        .ReverseMap()
        .ForPath(x => x.Articulo.archivos, op => op.MapFrom(x => x.Articulo.archivos))
        .ForMember(x => x.Articulo, op => op.MapFrom(x => x.Articulo));

        CreateMap<ArticuloCategoriaCreateDTO, ArticuloCategoria>()
            .ForMember(x => x.Articulo, articulo => articulo.MapFrom(ar => ar.Articulo))
            .ForPath(x => x.Articulo.archivos, archivo => archivo.MapFrom(ar => ar.Articulo.archivos))
            .ReverseMap();
    }
}