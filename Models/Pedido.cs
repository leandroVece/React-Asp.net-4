using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace Cadeteria.Models;

public partial class Pedido
{
    public Guid id { get; set; }
    [NotMapped]
    [JsonIgnore]
    public virtual Guid CadeteForeingKey { get; set; }
    public virtual Guid ClienteForeingKey { get; set; }
    public string Obs { get; set; }
    public string Estado { get; set; }

    [NotMapped]
    [JsonIgnore]
    public virtual Profile? Cliente { get; set; }

    [NotMapped]
    [JsonIgnore]
    public virtual User? Cadete { get; set; }

    [NotMapped]
    [JsonIgnore]
    public virtual CadetesPedido? Cadp { get; set; }
}