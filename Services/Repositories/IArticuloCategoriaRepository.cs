using Cadeteria.DTOs;
using Cadeteria.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
//using System.Data.SQLite;


namespace Cadeteria;


public interface IArticuloCategoriaRepository
{
    ArticuloCategoriaDTO Get(Guid id);
    Task<List<ArticuloCategoriaDTO>> Get2(FilterArticulo filtro, int page);
    Task Save(ArticuloCategoria artCad);
    Task Delete(Guid id);

}

