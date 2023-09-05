using Cadeteria.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
//using System.Data.SQLite;


namespace Cadeteria;

public interface IPedidoRepository
{
    public IEnumerable<Pedido> Get();
    Task Save(Pedido pedido);
    Task SaveCP(CadetesPedido cadp);
    Task Update(Guid id, Pedido pedido);
    Task Delete(Guid id);

}

