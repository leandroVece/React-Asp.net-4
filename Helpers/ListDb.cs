using Cadeteria.Models;

namespace Cadeteria;
using BCrypt.Net;
public class listaDb
{
    public static List<Profile> listaPerfil()
    {
        List<Profile> perfiles = new List<Profile>();
        perfiles.Add(new Profile()
        {
            id = Guid.Parse("7b5e9399-8e95-4ae8-8745-9542a01e2cc0"),
            userForeiKey = Guid.Parse("e0bd0d60-7ff8-43a6-b78b-8dc67780c8c9"),
            Nombre = "Jaun Castellanos",
            Direccion = "Entre rios",
            Telefono = "231321231"
        });
        perfiles.Add(new Profile()
        {
            id = Guid.Parse("0a9fa564-0604-4dfa-88df-3636fe395651"),
            userForeiKey = Guid.Parse("2d58f017-e038-4efa-acc1-f5f9e2d08668"),
            Nombre = "Ana Hume",
            Direccion = "independencia",
            Telefono = "231321231"
        });
        perfiles.Add(new Profile()
        {
            id = Guid.Parse("0a9fa564-0604-4dfa-88df-3636fe395678"),
            userForeiKey = Guid.Parse("07899a8d-bc7f-46d4-8d23-b174203f8bb0"),
            Nombre = "Fer Hume",
            Direccion = "independencia",
            Telefono = "654321"
        });
        perfiles.Add(new Profile()
        {
            id = Guid.Parse("e04a530d-f4bb-4ff1-898f-b3c00160dc28"),
            userForeiKey = Guid.Parse("36126fee-fee7-4d62-a22e-959feb2dd013"),
            Nombre = "Pancho Estrada",
            Direccion = "corrientes",
            Telefono = "654321"
        });
        perfiles.Add(new Profile()
        {
            id = Guid.Parse("910381a0-3a65-4ab9-9929-44faca09b567"),
            userForeiKey = Guid.Parse("df0efb73-de14-4140-bbd0-c357148d89d1"),
            Nombre = "Chichu Han",
            Direccion = "cordoba",
            Telefono = "654321"
        });
        perfiles.Add(new Profile()
        {
            id = Guid.Parse("b140ee23-f61b-45a7-8ef0-177d5c76a317"),
            userForeiKey = Guid.Parse("e2a4980f-7c50-45b0-aba5-6a46d79cf328"),
            Nombre = "Jessy Jade",
            Direccion = "italia",
            Telefono = "654321"
        });
        perfiles.Add(new Profile()
        {
            id = Guid.Parse("4978a844-a5d3-4d32-86e9-7046eefddea2"),
            userForeiKey = Guid.Parse("19ccc667-10c5-47b7-abd0-bae699c1cd3e"),
            Nombre = "Jaun Antonio",
            Direccion = "Entre rios",
            Telefono = "231321231"
        });
        perfiles.Add(new Profile()
        {
            id = Guid.Parse("e41d99f0-2afd-4c25-b677-514bcf897f6b"),
            userForeiKey = Guid.Parse("afaa31d8-013f-4dee-b21a-f9d03278d26a"),
            Nombre = "Ana Pradera",
            Direccion = "independencia",
            Telefono = "231321231"
        });
        perfiles.Add(new Profile()
        {
            id = Guid.Parse("2544db67-7dd3-4a16-99ec-7f1451c00558"),
            userForeiKey = Guid.Parse("c9d6ff8f-82ac-4eef-80df-de4999c4bb45"),
            Nombre = "Fer Nanda",
            Direccion = "independencia",
            Telefono = "654321"
        });
        perfiles.Add(new Profile()
        {
            id = Guid.Parse("a8bc0306-f0d1-46bb-b2b4-44104bb0e017"),
            userForeiKey = Guid.Parse("c036633e-2b76-498b-9b82-cfbb4f6a95a8"),
            Nombre = "Tu unico Proveedor",
            Direccion = "independencia y alem",
            Telefono = "3812342"
        });

        return perfiles;
    }
    public static List<User> ListUser()
    {
        List<User> listUser = new List<User>();

        listUser.Add(new User()
        {
            Id = Guid.Parse("e2a4980f-7c50-45b0-aba5-6a46d79cf328"),
            rolForeikey = Guid.Parse("7aafd6fb-612e-42c7-99db-cbec0fdad96f"),
            //profileForeikey = Guid.Parse("7b5e9399-8e95-4ae8-8745-9542a01e2cc0"),
            userName = "admin",
            password = BCrypt.HashPassword("admin")
        });
        listUser.Add(new User()
        {
            Id = Guid.Parse("c036633e-2b76-498b-9b82-cfbb4f6a95a8"),
            rolForeikey = Guid.Parse("c434c64a-5699-431e-8a88-a3ede659ba3d"),
            //profileForeikey = Guid.Parse("7b5e9399-8e95-4ae8-8745-9542a01e2cc0"),
            userName = "proveedor",
            password = BCrypt.HashPassword("proveedor")
        });
        listUser.Add(new User()
        {
            Id = Guid.Parse("df0efb73-de14-4140-bbd0-c357148d89d1"),
            rolForeikey = Guid.Parse("7a86db69-1474-4d92-a18e-91899d876c92"),
            //profileForeikey = Guid.Parse("0a9fa564-0604-4dfa-88df-3636fe395651"),
            userName = "cadete",
            password = BCrypt.HashPassword("cadete")
        });
        listUser.Add(new User()
        {
            Id = Guid.Parse("36126fee-fee7-4d62-a22e-959feb2dd013"),
            rolForeikey = Guid.Parse("f0601b48-a878-4fb5-a767-3f1340b8c0d8"),
            //profileForeikey = Guid.Parse("0a9fa564-0604-4dfa-88df-3636fe395678"),
            userName = "cliente",
            password = BCrypt.HashPassword("cliente")
        });
        listUser.Add(new User()
        {
            Id = Guid.Parse("19ccc667-10c5-47b7-abd0-bae699c1cd3e"),
            rolForeikey = Guid.Parse("f0601b48-a878-4fb5-a767-3f1340b8c0d8"),
            //profileForeikey = Guid.Parse("0a9fa564-0604-4dfa-88df-3636fe395678"),
            userName = "cliente01",
            password = BCrypt.HashPassword("cliente")
        });
        listUser.Add(new User()
        {
            Id = Guid.Parse("afaa31d8-013f-4dee-b21a-f9d03278d26a"),
            rolForeikey = Guid.Parse("f0601b48-a878-4fb5-a767-3f1340b8c0d8"),
            //profileForeikey = Guid.Parse("b140ee23-f61b-45a7-8ef0-177d5c76a317"),
            userName = "cliente2",
            password = BCrypt.HashPassword("cliente2")
        });
        listUser.Add(new User()
        {
            Id = Guid.Parse("c9d6ff8f-82ac-4eef-80df-de4999c4bb45"),
            rolForeikey = Guid.Parse("f0601b48-a878-4fb5-a767-3f1340b8c0d8"),
            //profileForeikey = Guid.Parse("910381a0-3a65-4ab9-9929-44faca09b567"),
            userName = "cliente3",
            password = BCrypt.HashPassword("cliente3")
        });
        listUser.Add(new User()
        {
            Id = Guid.Parse("07899a8d-bc7f-46d4-8d23-b174203f8bb0"),
            rolForeikey = Guid.Parse("f0601b48-a878-4fb5-a767-3f1340b8c0d8"),
            //profileForeikey = Guid.Parse("b140ee23-f61b-45a7-8ef0-177d5c76a317"),
            userName = "cliente02",
            password = BCrypt.HashPassword("cliente2")
        });
        listUser.Add(new User()
        {
            Id = Guid.Parse("2d58f017-e038-4efa-acc1-f5f9e2d08668"),
            rolForeikey = Guid.Parse("f0601b48-a878-4fb5-a767-3f1340b8c0d8"),
            //profileForeikey = Guid.Parse("910381a0-3a65-4ab9-9929-44faca09b567"),
            userName = "cliente03",
            password = BCrypt.HashPassword("cliente3")
        });
        listUser.Add(new User()
        {
            Id = Guid.Parse("e0bd0d60-7ff8-43a6-b78b-8dc67780c8c9"),
            rolForeikey = Guid.Parse("f0601b48-a878-4fb5-a767-3f1340b8c0d8"),
            //profileForeikey = Guid.Parse("e04a530d-f4bb-4ff1-898f-b3c00160dc28"),
            userName = "cadete2",
            password = BCrypt.HashPassword("cadete2")
        });

        return listUser;
    }
    public static List<Pedido> listPedido()
    {
        List<Pedido> Listped = new List<Pedido>();
        Listped.Add(new Pedido()
        {
            id = Guid.Parse("adc4aba6-b2b6-4ca6-a715-e563987fd02e"),
            ClienteForeingKey = Guid.Parse("0a9fa564-0604-4dfa-88df-3636fe395678"),
            Obs = "Coca",
            Estado = "Pendiente"
        });

        return Listped;
    }

    public static List<Rol> listRol()
    {
        List<Rol> listRol = new List<Rol>();
        listRol.Add(new Rol()
        {
            Id = Guid.Parse("7aafd6fb-612e-42c7-99db-cbec0fdad96f"),
            rolName = "admin"
        });
        listRol.Add(new Rol()
        {
            Id = Guid.Parse("7a86db69-1474-4d92-a18e-91899d876c92"),
            rolName = "cadete"
        });
        listRol.Add(new Rol()
        {
            Id = Guid.Parse("f0601b48-a878-4fb5-a767-3f1340b8c0d8"),
            rolName = "cliente"
        });
        listRol.Add(new Rol()
        {
            Id = Guid.Parse("c434c64a-5699-431e-8a88-a3ede659ba3d"),
            rolName = "provedor"
        });

        return listRol;
    }
}


