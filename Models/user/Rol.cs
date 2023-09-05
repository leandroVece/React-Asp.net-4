using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Cadeteria.Models;

public class Rol
{

    public Guid Id { get; set; }
    public string rolName { get; set; }

    [NotMapped]
    [JsonIgnore]
    public virtual ICollection<User>? User { get; set; }

}