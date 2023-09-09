using System.Linq;
using Cadeteria.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Cadeteria.DTOs;
using NLog;
using NLog.Fluent;

namespace Cadeteria;

[ApiController]
[Route("api/[controller]")]
public class ArchivoController : ControllerBase
{
    private readonly DataContext _db;
    private readonly ILogger<ArchivoController> _logger;
    private IMapper _mapper;
    private readonly IWebHostEnvironment _evriroment;
    private readonly IArchivoRepository _archivo;
    private readonly IArchivoHelpers _helpers;



    public ArchivoController(ILogger<ArchivoController> logger,
     DataContext db, IMapper mapper, IWebHostEnvironment environment, IArchivoRepository archivo,
     IArchivoHelpers helpers)
    {
        _evriroment = environment;
        _mapper = mapper;
        _db = db;
        _logger = logger;
        _archivo = archivo;
        _helpers = helpers;
    }
    [HttpGet]
    [Route("perfil")]
    public async Task<IActionResult> GetPage(string ruta)
    {
        try
        {
            if (ruta != null)
            {
                using (var fs = new FileStream(ruta, FileMode.Open, FileAccess.Read))
                {
                    using (var ms = new MemoryStream())
                    {
                        await fs.CopyToAsync(ms);
                        return Ok(ms.ToArray());
                    }
                }
            }
            return Ok();
        }
        catch (System.Exception e)
        {
            Console.WriteLine("no se pudo: \n" + e.ToString());
            return Ok();
        }
    }
    // [HttpGet]
    // Route[("articulo")]

    // public IActionResult GetPage()
    // {
    //     try
    //     {
    //         return Ok(_db.Archivo);
    //     }
    //     catch (System.Exception e)
    //     {
    //         Console.WriteLine("no se pudo: \n" + e.ToString());
    //         return Ok();
    //     }
    // }

    [HttpPost]
    [Route("articulo/{id}")]
    public IActionResult Post(Guid id, [FromForm] ArchivoRequesDTO archivo)
    {
        var data = _helpers.ConvertArchivo(_evriroment, archivo.Foto);
        var response = _mapper.Map<Archivo>(data);
        response.articulolForeiKey = id;
        _archivo.SaveArticulo(response);
        return Ok();
    }

    [HttpPut]
    [Route("articulo/{id}")]
    public IActionResult Put(Guid id, [FromForm] ArchivoUpdateDTO archivo)
    {
        _helpers.TruncateArchivo(archivo);
        // var data = ArchivoHelpers.ConvertArchivo(_evriroment, archivo.Foto);
        // var response = _mapper.Map<Archivo>(data);
        // response.Id = id;
        // _archivo.SaveArticulo(response);
        return Ok();
    }

    [HttpPost]
    [Route("perfil/{id}")]
    public IActionResult PostPerfil(Guid id, [FromForm] ArchivoRequesDTO archivo)
    {
        try
        {
            var data = _helpers.ConvertArchivo(_evriroment, archivo.Foto);
            var response = _mapper.Map<ArchivoPerfil>(data);
            response.perfilForeiKey = id;
            _archivo.SavePerfil(response);
            _logger.LogDebug("desde arcjhivos");
            return Ok();

        }
        catch (System.Exception e)
        {
            _logger.LogError(e.ToString());
            return Ok(e.ToString());
        }
    }

    [HttpPut]
    [Route("perfil/{id}")]
    public IActionResult PutPelfil(Guid id, [FromForm] ArchivoUpdateDTO archivo)
    {
        _helpers.TruncateArchivo(archivo);
        // var response = _mapper.Map<ArchivoPerfil>(archivo);
        // response.Id = id;
        // _archivo.UpdatePerfil(id, response);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        try
        {
            return Ok();

        }
        catch (System.Exception e)
        {
            Console.WriteLine(e.ToString());
            throw;
        }
    }

}