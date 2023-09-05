using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Cadeteria.Models;

public class Categoria
{
    public int Id { get; set; }
    public string Name { get; set; }
    [NotMapped]
    [JsonIgnore]
    public virtual List<Articulo> articulos { get; set; }
    [NotMapped]
    [JsonIgnore]
    public virtual List<ArticuloCategoria> ArticuloCategoria { get; set; }
}