using Cadeteria.Models;

namespace Cadeteria;

public class PedidoRepository : IPedidoRepository
{
    DataContext context;
    public PedidoRepository(DataContext dbContext)
    {
        context = dbContext;
    }

    public IEnumerable<Pedido> Get()
    {
        return context.Pedido;
    }

    public async Task Save(Pedido pedido)
    {
        context.Add(pedido);
        await context.SaveChangesAsync();
    }
    public async Task SaveCP(CadetesPedido cadp)
    {
        context.Add(cadp);
        await context.SaveChangesAsync();
    }

    public async Task Update(Guid id, Pedido pedido)
    {
        var pedidoAux = context.Pedido.Find(id);
        Console.WriteLine(id);

        if (pedidoAux != null)
        {
            pedidoAux.Estado = pedido.Estado;
            pedidoAux.Obs = pedido.Obs;
        }
        await context.SaveChangesAsync();
    }
    public async Task Delete(Guid id)
    {
        var pedidoAux = context.Pedido.Find(id);
        //Console.WriteLine(pedidoAux.Nombre + " " + id);
        if (pedidoAux != null)
        {
            context.Remove(pedidoAux);
            await context.SaveChangesAsync();
        }
    }


}
