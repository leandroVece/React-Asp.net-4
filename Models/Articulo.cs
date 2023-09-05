using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Cadeteria.Models;

public class Articulo
{
    public Guid Id { get; set; }
    [NotMapped]
    [JsonIgnore]
    public int categoriaForeiKey { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int stock { get; set; }
    public string? descripcion { get; set; }

    [NotMapped]
    [JsonIgnore]
    public virtual List<Categoria> categorias { get; set; }
    [NotMapped]
    [JsonIgnore]
    public virtual List<ArticuloCategoria> ArticuloCategoria { get; set; }

    [NotMapped]
    [JsonIgnore]
    public List<Archivo>? archivos { get; set; }
    //public virtual Archivo? archivos { get; set; }


}