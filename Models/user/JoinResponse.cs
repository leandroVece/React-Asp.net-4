using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Cadeteria.Models;

public class JoinResponse
{
    public Guid Id { get; set; }
    public Guid userForeiKey { get; set; }
    public string rolName { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public string Nombre { get; set; }
    public string Referencia { get; set; }

}