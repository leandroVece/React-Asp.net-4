using Cadeteria.Models;

namespace Cadeteria;
public interface IArchivoRepository
{
    IEnumerable<Archivo> Get();
    Task SaveArticulo(Archivo archivo);
    Task SavePerfil(ArchivoPerfil archivo);
    Task UpdateArticulo(Guid id, Archivo archivo);
    Task UpdatePerfil(Guid id, ArchivoPerfil archivo);
    Task DeleteArticulo(Guid id);
    Task DeletePerfil(Guid id);
}