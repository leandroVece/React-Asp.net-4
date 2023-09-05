namespace Cadeteria.Models;

using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

public class User
{
    public Guid Id { get; set; }
    public Guid rolForeikey { get; set; }
    public string userName { get; set; }
    public string password { get; set; }

    [NotMapped]
    [JsonIgnore]
    public Guid profileForeikey { get; set; }

    [NotMapped]
    [JsonIgnore]
    public virtual Rol? Rol { get; set; }
    [NotMapped]
    [JsonIgnore]
    public virtual Profile? Profile { get; set; }
    [NotMapped]
    [JsonIgnore]
    public virtual Calificacion? Calificacion { get; set; }

    [NotMapped]
    [JsonIgnore]
    public virtual ICollection<CadetesPedido>? Cadp { get; set; }

}


