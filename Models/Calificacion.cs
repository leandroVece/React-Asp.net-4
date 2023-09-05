
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Cadeteria.Models;

public class Calificacion
{
    public int Id { get; set; }
    public Guid userForeiKey { get; set; }
    public int? valor { get; set; }

    [NotMapped]
    [JsonIgnore]
    public virtual User? User { get; set; }

}