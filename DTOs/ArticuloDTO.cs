using Cadeteria.Models;

namespace Cadeteria.DTOs;

public class ArticuloDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int stock { get; set; }
    public string? descripcion { get; set; }
    //public List<ArchivoResponseDTO> archivo { get; set; }
    public List<ArchivoDTO>? archivos { get; set; }

}

public class ArticuloCreateDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int stock { get; set; }
    public string? descripcion { get; set; }
    public List<ArchivoCreateDTO>? archivos { get; set; }
    //public ArchivoCreateDTO? archivo { get; set; }

}

