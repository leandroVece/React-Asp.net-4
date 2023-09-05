namespace Cadeteria;

using Cadeteria.Models;

using BCrypt.Net;
using Cadeteria;

public class listaDb2
{
    public static List<ArticuloCategoria> ListaArtC()
    {


        List<ArticuloCategoria> ListArtC = new List<ArticuloCategoria>();

        ListArtC.Add(new ArticuloCategoria()
        {
            Id = Guid.Parse("55d553ae-0e7f-4f65-aefd-86fbb6ba0c70"),
            categoriaForeiKey = 1,
            articuloForeiKey = Guid.Parse("51d30e27-6782-473b-bf06-f0dff24d145f"),
        });
        ListArtC.Add(new ArticuloCategoria()
        {
            Id = Guid.Parse("fcb24de5-3374-4339-a7e3-64a155835da7"),
            categoriaForeiKey = 1,
            articuloForeiKey = Guid.Parse("0ac4774e-1616-464d-b827-99862f55ae7e"),
        });
        ListArtC.Add(new ArticuloCategoria()
        {
            Id = Guid.Parse("ba8a92c4-8a41-4b60-867e-c586ede13fde"),
            categoriaForeiKey = 1,
            articuloForeiKey = Guid.Parse("44de84e5-5a5a-4b07-a083-606c46a358ca"),
        });
        ListArtC.Add(new ArticuloCategoria()
        {
            Id = Guid.Parse("2d4532c3-4282-4190-9817-80fc6b543652"),
            categoriaForeiKey = 1,
            articuloForeiKey = Guid.Parse("cf9ee397-bba1-4522-adb7-cb9ff5842499"),
        });
        ListArtC.Add(new ArticuloCategoria()
        {
            Id = Guid.Parse("94db418a-7c53-433a-b135-46b670ddc372"),
            categoriaForeiKey = 2,
            articuloForeiKey = Guid.Parse("302eec33-3ec7-4664-9da4-32e98b3ee027"),
        });
        ListArtC.Add(new ArticuloCategoria()
        {
            Id = Guid.Parse("daf9fde7-9e3e-4b61-ad3b-f342fa712e4c"),
            categoriaForeiKey = 2,
            articuloForeiKey = Guid.Parse("646bec53-9328-40cf-9936-7ad0fd5c5983"),
        });
        ListArtC.Add(new ArticuloCategoria()
        {
            Id = Guid.Parse("f126372b-6855-4e24-bead-0843f5ce67a7"),
            categoriaForeiKey = 2,
            articuloForeiKey = Guid.Parse("ae679e76-b7e3-45bc-8b97-d6dd8ef16200"),
        });
        ListArtC.Add(new ArticuloCategoria()
        {
            Id = Guid.Parse("4e6eadcf-f982-43db-b8a4-641e426d564f"),
            categoriaForeiKey = 2,
            articuloForeiKey = Guid.Parse("bb55f434-2698-4d1f-98f8-2fccaa36bc21"),
        });


        // 2fb4b81e-0c5e-4783-aa26-6d96a25ef6f6
        // 576e1bfb-e5d8-4687-9c5c-9f093beb1471

        return ListArtC;
    }
    public static List<Articulo> ListArticulos()
    {

        List<Articulo> ListArticulos = new List<Articulo>();
        ListArticulos.Add(new Articulo()
        {
            Id = Guid.Parse("302eec33-3ec7-4664-9da4-32e98b3ee027"),
            Name = "Celular Motorola",
            Price = 1500,
            stock = 3,
        });
        ListArticulos.Add(new Articulo()
        {
            Id = Guid.Parse("646bec53-9328-40cf-9936-7ad0fd5c5983"),
            Name = "Celular Sangsung",
            Price = 2500,
            stock = 3,
        });
        ListArticulos.Add(new Articulo()
        {
            Id = Guid.Parse("ae679e76-b7e3-45bc-8b97-d6dd8ef16200"),
            Name = "Celular Shiaomi",
            Price = 1200,
            stock = 3,
        });
        ListArticulos.Add(new Articulo()
        {
            Id = Guid.Parse("bb55f434-2698-4d1f-98f8-2fccaa36bc21"),
            Name = "Iphon",
            Price = 1000,
            stock = 3,
        });

        ListArticulos.Add(new Articulo()
        {
            Id = Guid.Parse("0ac4774e-1616-464d-b827-99862f55ae7e"),
            Name = "Micro razen 3200",
            Price = 500,
            stock = 3,
        });
        ListArticulos.Add(new Articulo()
        {
            Id = Guid.Parse("51d30e27-6782-473b-bf06-f0dff24d145f"),
            Name = "Micro intel i3 9100",
            Price = 500,
            stock = 3,
        });
        ListArticulos.Add(new Articulo()
        {
            Id = Guid.Parse("44de84e5-5a5a-4b07-a083-606c46a358ca"),
            Name = "Monitor 25",
            Price = 200,
            stock = 3,
        });
        ListArticulos.Add(new Articulo()
        {
            Id = Guid.Parse("cf9ee397-bba1-4522-adb7-cb9ff5842499"),
            Name = "Pc intel i3 9100 16GB ddr4",
            Price = 1000,
            stock = 3,
        });


        return ListArticulos;
    }

    public static List<Categoria> ListCategorias()
    {
        List<Categoria> ListCategor = new List<Categoria>();
        ListCategor.Add(new Categoria()
        {
            Id = 1,
            Name = "Informatica",
        });
        ListCategor.Add(new Categoria()
        {
            Id = 2,
            Name = "Celular",
        });

        return ListCategor;
    }

}


