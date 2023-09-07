using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Cadeteria.Models;

public class Archivo
{
    public Guid Id { get; set; }
    public Guid articulolForeiKey { get; set; }
    public string Name { get; set; }
    public string Foto { get; set; }

    [NotMapped]
    public byte[] img { get; set; }

    [NotMapped]
    [JsonIgnore]
    public Articulo articulo { get; set; }

}