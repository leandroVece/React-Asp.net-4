using Cadeteria.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
//using System.Data.SQLite;


namespace Cadeteria;


public interface IHistorialRepository
{
    public IEnumerable<Historial> Get();
    Task Save(Historial cadp);
    Task Delete(Guid id);

}

