namespace Cadeteria;
using Cadeteria.DTOs;
using Microsoft.AspNetCore.Hosting;

public interface IArchivoHelpers
{
    ArticuloCategoriaCreateDTO CreateArchivo(ArticuloCategoriaResponseDTO response, IWebHostEnvironment _evriroment);
    ArchivoCreateDTO ConvertArchivo(IWebHostEnvironment _evriroment, IFormFile archivo);
    void TruncateArchivo(ArchivoUpdateDTO archivo);
    void DeletetArchivo(ArchivoDTO archivo);

}
public class ArchivoHelpers : IArchivoHelpers
{
    public ArticuloCategoriaCreateDTO CreateArchivo(ArticuloCategoriaResponseDTO response, IWebHostEnvironment _evriroment)
    {

        ArticuloCategoriaCreateDTO data = new ArticuloCategoriaCreateDTO();
        List<ArchivoCreateDTO> aux = new List<ArchivoCreateDTO>();
        //ArchivoCreateDTO aux2;
        if (response.Foto != null)
        {

            // string ficherosImagenes = Path.Combine(_evriroment.ContentRootPath, "upload");
            // //            string ficherosImagenes = Path.Combine($"~./", "upload");
            // foreach (var item in response.Foto)
            // {
            //     nameImagen = $"{Path.GetRandomFileName()}.png";
            //     string rutaDefinitiva = Path.Combine(ficherosImagenes, nameImagen);
            //     aux.Add(new ArchivoCreateDTO { Name = nameImagen, Foto = rutaDefinitiva });
            //     using (var fileStream = new FileStream(rutaDefinitiva, FileMode.Create))
            //     {
            //         item.CopyTo(fileStream);
            //     };
            // }
            foreach (var item in response.Foto)
            {
                aux.Add(ConvertArchivo(_evriroment, item));
            }


            data.Articulo = new ArticuloCreateDTO()
            {
                Name = response.ArticuloName,
                Price = response.Price,
                descripcion = response.descripcion,
                stock = response.stock,
                archivos = aux
            };
        }
        else
        {
            data.Articulo = new ArticuloCreateDTO()
            {
                Name = response.ArticuloName,
                Price = response.Price,
                descripcion = response.descripcion,
                stock = response.stock,
            };
        }
        data.Categoria = new CategoriaDTO() { Name = response.CategoriaName };

        return data;
    }

    public ArchivoCreateDTO ConvertArchivo(IWebHostEnvironment _evriroment, IFormFile archivo)
    {
        //string path = Path.Combine(_evriroment.ContentRootPath, "wwwroot", "upload");
        string ficherosImagenes = Path.Combine(Path.Combine(_evriroment.ContentRootPath, "wwwroot", "upload"));
        if (!Directory.Exists(ficherosImagenes))
        {
            Directory.CreateDirectory(ficherosImagenes);
        }

        string nameImagen = $"{Path.GetRandomFileName()}.png";
        string rutaDefinitiva = Path.Combine(ficherosImagenes, nameImagen);
        using (var fileStream = new FileStream(rutaDefinitiva, FileMode.Create))
        {
            archivo.CopyToAsync(fileStream);
        };

        return new ArchivoCreateDTO { Name = nameImagen, Foto = rutaDefinitiva };
    }
    public void TruncateArchivo(ArchivoUpdateDTO archivo)
    {

        using (var fileStream = new FileStream(archivo.Foto, FileMode.Truncate))
        {
            archivo.newFoto.CopyToAsync(fileStream);
        };

        //return new ArchivoCreateDTO { Name = nameImagen, Foto = rutaDefinitiva };
    }
    public void DeletetArchivo(ArchivoDTO archivo)
    {
        if (File.Exists(archivo.Foto))
        {
            File.Delete(archivo.Foto);
        }
    }
}