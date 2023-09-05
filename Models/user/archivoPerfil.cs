using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Cadeteria.Models;

public class ArchivoPerfil
{
    public Guid Id { get; set; }
    public Guid perfilForeiKey { get; set; }
    public string Name { get; set; }
    public string Foto { get; set; }

    [NotMapped]
    [JsonIgnore]
    public Profile perfil { get; set; }

}