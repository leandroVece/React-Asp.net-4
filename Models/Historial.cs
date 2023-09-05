using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Cadeteria.Models;

public class Historial
{
    public Guid id { get; set; }
    public virtual Guid userForeingKey { get; set; }
    public virtual Guid profileForeingKey { get; set; }

    [NotMapped]
    [JsonIgnore]
    public virtual User? Cadete { get; set; }

    [NotMapped]
    [JsonIgnore]
    public virtual Profile? Cliente { get; set; }
}