using Cadeteria.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
//using System.Data.SQLite;


namespace Cadeteria;


public interface ICadetePedidoRepository
{
    public IEnumerable<CadetesPedido> Get();
    Task Save(CadetesPedido cadp);
    Task Delete(Guid id);

    // SQLiteConnection Conexion();
    // public void Update(Pedido pedido);
    // public void Delete(string numero);
    // public void Create(Pedido pedido,int Id_cliente);

    // List<Pedido> GetPedido();
    // Pedido GetPedidoById(string Numero);

}

