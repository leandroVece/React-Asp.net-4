using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Cadeteria.Models;
public class Profile
{
    public Guid id { get; set; }
    public Guid userForeiKey { get; set; }
    public string Nombre { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public string? Referencia { get; set; }

    [NotMapped]
    [JsonIgnore]
    public virtual ICollection<Pedido>? listaPedido { get; set; }

    [NotMapped]
    [JsonIgnore]
    public virtual List<Historial>? CadClien { get; set; }

    [NotMapped]
    [JsonIgnore]
    public virtual User? User { get; set; }
    [NotMapped]
    [JsonIgnore]
    public virtual ArchivoPerfil? archivo { get; set; }
}
