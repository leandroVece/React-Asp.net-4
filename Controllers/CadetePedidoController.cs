using Cadeteria.Authorization;
using Cadeteria.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cadeteria;


[ApiController]
[Route("api/[controller]")]
public class CadetePedidoController : ControllerBase
{
    private readonly DataContext _db;
    private readonly ICadetePedidoRepository _cp;
    private readonly ILogger<CadetePedidoController> _logger;

    public CadetePedidoController(ILogger<CadetePedidoController> logger, ICadetePedidoRepository cp, DataContext db)
    {
        _db = db;
        _cp = cp;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Get()
    {
        try
        {

            var response = _db.Profile.Join(_db.Pedido, client => client.id, ped => ped.ClienteForeingKey,
              (client, ped) => new { ped.id, ped.ClienteForeingKey, ped.Obs, ped.Estado, client.Nombre })
              .Where(x => x.Estado == "Pendiente").ToList();
            return Ok(response);
        }
        catch (System.Exception e)
        {
            Console.WriteLine("no se pudo: \n" + e.ToString());
            return Ok();
        }
    }
    [HttpGet]
    [Route("action/{id}")]
    public IActionResult GetLista(Guid id)
    {
        try
        {
            // var response = _db.Profile.Join(_db.Pedido, client => client.id, ped => ped.ClienteForeingKey,
            //   (client, ped) => new { ped.id, ped.ClienteForeingKey, ped.Obs, ped.Estado, client.Nombre })
            //   .Where(x => x.Estado == "En camino").ToList();

            var response = _db.CadPed.Join(_db.Pedido, cadp => cadp.pedidoForeingKey, ped => ped.id,
                (cadp, ped) => new { cadp.id, cadp.pedidoForeingKey, cadp.userForeingKey, ped.Obs, ped.Estado, ped.ClienteForeingKey })
                .Where(x => x.userForeingKey == id && x.Estado == "En camino");
            return Ok(response);
        }
        catch (System.Exception e)
        {
            Console.WriteLine("no se pudo: \n" + e.ToString());
            return Ok();
        }
    }

    [HttpPost]
    public IActionResult Post([FromBody] CadetesPedido cadp)
    {

        try
        {
            _cp.Save(cadp);
            return Ok();
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
        _cp.Delete(id);
        return Ok();
    }
}
