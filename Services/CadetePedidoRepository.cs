using Cadeteria.Models;

namespace Cadeteria;

public class CadetePedidoRepository : ICadetePedidoRepository
{

    DataContext context;
    public CadetePedidoRepository(DataContext dbContext)
    {
        context = dbContext;
    }

    public IEnumerable<CadetesPedido> Get()
    {
        return context.CadPed;
    }

    public async Task Save(CadetesPedido cadp)
    {
        context.Add(cadp);
        await context.SaveChangesAsync();
    }

    public async Task Delete(Guid id)
    {
        var cp = context.CadPed.Find(id);
        //Console.WriteLine(pedidoAux.Nombre + " " + id);
        if (cp != null)
        {
            context.Remove(cp);
            await context.SaveChangesAsync();
        }
    }

}
