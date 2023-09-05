using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Cadeteria.Models;

public class ArticuloCategoria
{
    public Guid Id { get; set; }
    public int categoriaForeiKey { get; set; }
    public Guid articuloForeiKey { get; set; }

    // [NotMapped]
    // [JsonIgnore]
    public virtual Articulo? Articulo { get; set; }

    [NotMapped]
    [JsonIgnore]
    public virtual Categoria? Categoria { get; set; }
}