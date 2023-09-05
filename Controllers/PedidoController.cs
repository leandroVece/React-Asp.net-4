using System.Linq;
using Cadeteria.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace Cadeteria;

[ApiController]
[Route("api/[controller]")]
public class PedidoController : ControllerBase
{
    private readonly DataContext _db;
    private readonly IPedidoRepository _dbPedido;
    private readonly ILogger<PedidoController> _logger;
    private IMapper _mapper;

    public PedidoController(ILogger<PedidoController> logger,
     IPedidoRepository pedido, DataContext db, IMapper mapper)
    {
        _dbPedido = pedido;
        _mapper = mapper;
        _db = db;
        _logger = logger;
    }

    [HttpGet]
    [Route("page/{page:int?}")]
    public IActionResult GetPage(int? page = 1)
    {
        try
        {
            List<PedidoResponce> res = new List<PedidoResponce>();
            var respose = _db.Pedido.Join(_db.Profile, ped => ped.ClienteForeingKey, pf => pf.id,
            (ped, pf) => new { ped.id, ped.Estado, ped.Obs, ped.ClienteForeingKey, pf.Nombre }
            )
                .Skip(((int)page - 1) * 1)
                .Take(2);

            foreach (var item in respose)
            {
                res.Add(new PedidoResponce()
                {
                    Id = item.id,
                    ClienteForeingKey = item.ClienteForeingKey,
                    Obs = item.Obs,
                    Estado = item.Estado,
                    Nombre = item.Nombre,
                });
            }

            var totalRecords = _dbPedido.Get().Count();
            return Ok(new PagedResponse<IEnumerable<PedidoResponce>>(
                        res, totalRecords / 1, (int)page));
        }
        catch (System.Exception e)
        {
            Console.WriteLine("no se pudo: \n" + e.ToString());
            return Ok();
        }
    }


    [HttpGet("{id:guid}/page/{page:int?}")]
    public IActionResult GetByCliente(Guid id, int? page = 1)
    {

        try
        {
            List<PedidoResponce> res = new List<PedidoResponce>();
            var respose = _db.Pedido.Join(_db.Profile, ped => ped.ClienteForeingKey, pf => pf.id,
            (ped, pf) => new { ped.id, ped.Estado, ped.Obs, ped.ClienteForeingKey, pf.Nombre }
            )
            .Where(p => p.ClienteForeingKey == id)
                .Skip(((int)page - 1) * 1)
                .Take(2);

            foreach (var item in respose)
            {
                res.Add(new PedidoResponce()
                {
                    Id = item.id,
                    ClienteForeingKey = item.ClienteForeingKey,
                    Obs = item.Obs,
                    Estado = item.Estado,
                    Nombre = item.Nombre,
                });
            }

            //res = _mapper.Map<List<PedidoResponce>>(respose);

            var totalRecords = _dbPedido.Get().Where(p => p.ClienteForeingKey == id).Count();
            return Ok(new PagedResponse<IEnumerable<PedidoResponce>>(
                        res, totalRecords / 1, (int)page));
        }
        catch (System.Exception e)
        {
            Console.WriteLine("no se pudo: \n" + e.ToString());
            return Ok();
        }
    }




    [HttpPost]
    public IActionResult Post([FromBody] Pedido pedido)
    {
        _dbPedido.Save(pedido);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] Pedido pedido)
    {
        _dbPedido.Update(id, pedido);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        try
        {
            Console.WriteLine(id);
            _dbPedido.Delete(id);
            return Ok();

        }
        catch (System.Exception e)
        {
            Console.WriteLine(e.ToString());
            throw;
        }
    }

}