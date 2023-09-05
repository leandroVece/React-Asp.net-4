using AutoMapper;
using Cadeteria.Models;

namespace Cadeteria;

public class ArchivoRepository : IArchivoRepository
{

    DataContext context;
    private readonly IMapper _mapper;
    public ArchivoRepository(DataContext dbContext, IMapper mapper)
    {
        context = dbContext;
        _mapper = mapper;
    }

    public IEnumerable<Archivo> Get()
    {
        return context.Archivo;
    }


    public async Task SaveArticulo(Archivo archivo)
    {
        context.Add(archivo);
        await context.SaveChangesAsync();
    }
    public async Task SavePerfil(ArchivoPerfil archivo)
    {
        context.Add(archivo);
        await context.SaveChangesAsync();
    }

    public async Task UpdateArticulo(Guid id, Archivo archivo)
    {
        var archivoAux = context.Archivo.Find(id);
        if (archivoAux != null)
        {
            archivoAux.Name = archivo.Name;
            archivoAux.Foto = archivo.Foto;
        }
        await context.SaveChangesAsync();
    }
    public async Task UpdatePerfil(Guid id, ArchivoPerfil archivo)
    {
        var archivoAux = context.Archivo.Find(id);
        if (archivoAux != null)
        {
            archivoAux.Name = archivo.Name;
            archivoAux.Foto = archivo.Foto;
        }
        await context.SaveChangesAsync();
    }

    public async Task DeleteArticulo(Guid id)
    {
        var archivo = context.Archivo.Find(id);
        if (archivo != null)
        {
            context.Remove(archivo);
            await context.SaveChangesAsync();
        }
    }
    public async Task DeletePerfil(Guid id)
    {
        var archivo = context.ArchivoPerfil.Find(id);
        if (archivo != null)
        {
            context.Remove(archivo);
            await context.SaveChangesAsync();
        }
    }

}