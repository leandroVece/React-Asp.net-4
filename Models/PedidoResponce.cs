using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace Cadeteria.Models;

public partial class PedidoResponce
{
    public virtual Guid Id { get; set; }
    public virtual Guid ClienteForeingKey { get; set; }
    public string Obs { get; set; }
    public string Estado { get; set; }
    public string Nombre { get; set; }


}