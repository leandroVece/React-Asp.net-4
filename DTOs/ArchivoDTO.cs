using Cadeteria.Models;

namespace Cadeteria.DTOs;


public class ArchivoCreateDTO
{
    public string Name { get; set; }
    public string Foto { get; set; }
}
public class ArchivoRequesDTO
{
    public IFormFile Foto { get; set; }
}
public class ArchivoUpdateDTO
{
    public string Foto { get; set; }
    public IFormFile newFoto { get; set; }
}
public class ArchivoDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Foto { get; set; }
    //public byte[] img { get; set; }

}
