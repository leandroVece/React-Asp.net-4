using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Cadeteria.Models;

public class CadetesPedido
{

    public Guid id { get; set; }
    public virtual Guid userForeingKey { get; set; }
    public virtual Guid pedidoForeingKey { get; set; }

    [NotMapped]
    [JsonIgnore]
    public virtual User? Cadete { get; set; }

    [NotMapped]
    [JsonIgnore]
    public virtual Pedido? Pedido { get; set; }

}