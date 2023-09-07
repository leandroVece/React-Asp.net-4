//using System.Data.SQLite;
//using AutoMapper;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Cadeteria.DTOs;
using Cadeteria.Models;
using Microsoft.EntityFrameworkCore;
using LinqKit;

namespace Cadeteria;

public class ArticuloCategoriaRepository : IArticuloCategoriaRepository
{

    DataContext context;
    private readonly IMapper _mapper;
    public ArticuloCategoriaRepository(DataContext dbContext, IMapper mapper)
    {
        context = dbContext;
        _mapper = mapper;
    }

    public ArticuloCategoriaDTO Get(Guid id)
    {
        var response = context.ArticuloCategoria
        .ProjectTo<ArticuloCategoriaDTO>(_mapper.ConfigurationProvider)
        .Where(x => x.Id == id)
        .SingleOrDefault();
        return response;
    }
    public async Task<List<ArticuloCategoriaDTO>> Get2(FilterArticulo filtro, int page)
    {
        var predicate = PredicateBuilder.New<ArticuloCategoria>();
        predicate = predicate.Or(p => p.Articulo.Name.Contains(filtro.ArticuloName));
        predicate = predicate.Or(p => p.Categoria.Name.Contains(filtro.CategoriaName));
        predicate = predicate.Or(p => p.Articulo.Price >= filtro.PriceMin && p.Articulo.Price <= filtro.PriceMax);

        var response = await context.ArticuloCategoria
        .Include(p => p.Articulo.archivos)
        .Where(predicate)
         .Skip((page - 1) * 4)
         .Take(4)
        .OrderBy(x => x.Articulo.Price)
        .ToListAsync();

        return _mapper.Map<List<ArticuloCategoriaDTO>>(response);
    }

    public async Task Save(ArticuloCategoria artCad)
    {
        //context.ArticuloCategoria.Add(artCad);
        var aux = artCad;
        var categoria = context.Categoria.SingleOrDefault(x => x.Name == artCad.Categoria.Name);
        if (categoria != null)
        {
            aux.categoriaForeiKey = categoria.Id;
            artCad.Categoria = null;
        }

        context.ArticuloCategoria.Add(aux);
        await context.SaveChangesAsync();
    }

    public async Task Delete(Guid id)
    {
        //si se borra una articulo, la relacion debe ser borrada articulo-articuloCategoria
        var cp = context.CadPed.Find(id);
        //Console.WriteLine(pedidoAux.Nombre + " " + id);
        if (cp != null)
        {
            context.Remove(cp);
            await context.SaveChangesAsync();
        }
    }


}
