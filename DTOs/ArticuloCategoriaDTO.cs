using Cadeteria.Models;

namespace Cadeteria.DTOs;

public class ArticuloCategoriaDTO
{
    public Guid Id { get; set; }
    public ArticuloDTO Articulo { get; set; }
    public CategoriaDTO Categoria { get; set; }

}
public class ArticuloCategoriaCreateDTO
{
    public Guid Id { get; set; }
    public ArticuloCreateDTO Articulo { get; set; }
    public CategoriaDTO Categoria { get; set; }

}
public class ArticuloCategoriaResponseDTO
{

    public string CategoriaName { get; set; }
    public string ArticuloName { get; set; }
    public decimal Price { get; set; }
    public int stock { get; set; }
    public string? descripcion { get; set; }
    public List<IFormFile>? Foto { get; set; }
    //public IFormFile? Foto { get; set; }
}


