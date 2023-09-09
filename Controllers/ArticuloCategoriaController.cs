using AutoMapper;
using Cadeteria.DTOs;
using Cadeteria.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cadeteria;


[Route("[controller]")]
public class ArticuloCategoriaController : ControllerBase
{
    private readonly DataContext _db;
    private readonly IArticuloCategoriaRepository _articulo;
    private readonly ILogger<ArticuloCategoriaController> _logger;
    private readonly IMapper _mapper;
    private readonly IWebHostEnvironment _evriroment;
    private readonly IArchivoHelpers _helpers;


    public ArticuloCategoriaController(ILogger<ArticuloCategoriaController> logger, IArticuloCategoriaRepository articulo, DataContext db, IMapper mapper, IWebHostEnvironment env,
    IArchivoHelpers helpers)
    {
        _db = db;
        _articulo = articulo;
        _logger = logger;
        _mapper = mapper;
        _evriroment = env;
        _helpers = helpers;
    }

    // [HttpGet]
    // public IActionResult Get()
    // {
    //     try
    //     {
    //         var response = _articulo.Get();
    //         return Ok(new PagedResponse<IEnumerable<ArticuloCategoriaDTO>>(
    //         response, 2 / 1, 1));
    //     }
    //     catch (System.Exception e)
    //     {
    //         Console.WriteLine("no se pudo: \n" + e.ToString());
    //         return Ok("no se pudo: \n" + e.ToString());
    //     }
    // }
    [HttpGet]
    [Route("categorias")]
    public IActionResult GetCategorias()
    {
        try
        {
            var response = _db.Categoria;
            return Ok(response);

        }
        catch (System.Exception e)
        {
            Console.WriteLine("no se pudo: \n" + e.ToString());
            return Ok("no se pudo: \n" + e.ToString());
        }
    }
    [HttpPost]
    [Route("filtro/{page:int?}")]
    public async Task<IActionResult> Getfiltro([FromBody] FilterArticulo filtro, int? page = 1)
    {
        try
        {
            List<ArticuloCategoriaDTO> response = await _articulo.Get2(filtro, (int)page);

            // foreach (var item in response)
            // {
            //     if (item.Articulo?.archivos.Count > 0)
            //     {
            //         if (System.IO.File.Exists(item.Articulo?.archivos[0].Foto))
            //         {
            //             var path = item.Articulo.archivos[0].Foto;
            //             using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            //             {
            //                 using (var ms = new MemoryStream())
            //                 {
            //                     await fs.CopyToAsync(ms);
            //                     item.Articulo.archivos[0].img = ms.ToArray();
            //                 }
            //             }
            //         }
            //     }
            // }

            int totalRecords = (int)Math.Ceiling((decimal)_db.Articulo.Count() / 4);
            return Ok(new PagedResponse<IEnumerable<ArticuloCategoriaDTO>>(
             response, totalRecords, (int)page));
        }
        catch (System.Exception e)
        {
            Console.WriteLine("no se pudo: \n" + e.ToString());
            return Ok("no se pudo: \n" + e.ToString());
        }
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        try
        {
            var response = _articulo.Get(id);
            return Ok(response);

        }
        catch (System.Exception e)
        {
            Console.WriteLine("no se pudo: \n" + e.ToString());
            return Ok();
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromForm] ArticuloCategoriaResponseDTO articulo)
    {
        try
        {
            var data = _helpers.CreateArchivo(articulo, _evriroment);
            var request = _mapper.Map<ArticuloCategoria>(data);
            await _articulo.Save(request);
            return Ok();
        }
        catch (System.Exception e)
        {
            Console.WriteLine("error: \n" + e.ToString());
            throw;
        }
    }

    [HttpPost]
    [Route("prueba")]
    public IActionResult Post([FromBody] ArticuloCategoriaDTO articulo)
    {
        try
        {
            var request = _mapper.Map<ArticuloCategoria>(articulo);
            _articulo.Save(request);
            return Ok(request);
        }
        catch (System.Exception e)
        {
            Console.WriteLine("error: \n" + e.ToString());
            throw;
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        return Ok();
    }

}
