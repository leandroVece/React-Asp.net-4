using AutoMapper.Internal.Mappers;
using Cadeteria.Models;
using Microsoft.EntityFrameworkCore;

namespace Cadeteria;

public class DataContext : DbContext
{
    public DbSet<Profile> Profile { get; set; }
    public DbSet<Pedido> Pedido { get; set; }
    public DbSet<Historial> CadCliente { get; set; }
    public DbSet<CadetesPedido> CadPed { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Rol> Rols { get; set; }
    public DbSet<Articulo> Articulo { get; set; }
    public DbSet<ArticuloCategoria> ArticuloCategoria { get; set; }
    public DbSet<Categoria> Categoria { get; set; }
    public DbSet<Archivo> Archivo { get; set; }
    public DbSet<ArchivoPerfil> ArchivoPerfil { get; set; }

    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<User>(User =>
        {

            User.ToTable("usuario");
            User.HasKey(User => User.Id);
            User.Property(User => User.userName).IsRequired().HasMaxLength(15).IsUnicode();
            User.Property(User => User.password).IsRequired().HasMaxLength(80);
            //User.Property(User => User.rolForeikey).HasDefaultValue(Guid.Parse("E2A4980F-7C50-45B0-ABA5-6A46D79CF328"));

            User.HasOne(r => r.Rol).WithMany(us => us.User).HasForeignKey(r => r.rolForeikey);

            User.HasData(listaDb.ListUser());
        });

        modelBuilder.Entity<Profile>(profile =>
       {
           profile.ToTable("perfil");
           profile.HasKey(p => p.id);
           profile.Property(p => p.id).IsRequired().ValueGeneratedOnAdd();

           profile.Property(p => p.Nombre).IsRequired().HasMaxLength(20);
           profile.Property(p => p.Direccion).IsRequired().HasMaxLength(100);
           profile.Property(p => p.Telefono).IsRequired().HasMaxLength(20);
           profile.Property(p => p.Referencia);

           profile.HasOne(us => us.User).WithOne(p => p.Profile)
           .HasForeignKey<Profile>(p => p.userForeiKey)
           .OnDelete(DeleteBehavior.Cascade);

           profile.HasData(listaDb.listaPerfil());
       });

        modelBuilder.Entity<Rol>(R =>
       {

           R.ToTable("rol");
           R.HasKey(rol => rol.Id);
           R.Property(rol => rol.rolName).IsRequired().HasMaxLength(15).IsUnicode();

           R.HasData(listaDb.listRol());
       });

        modelBuilder.Entity<Pedido>(Pedido =>
        {

            Pedido.ToTable("pedido");
            Pedido.HasKey(p => p.id);
            Pedido.HasOne(cli => cli.Cliente)
            .WithMany(ped => ped.listaPedido)
            .HasForeignKey(c => c.ClienteForeingKey);

            Pedido.Property(p => p.id).IsRequired().ValueGeneratedOnAdd();
            Pedido.Property(p => p.Obs).IsRequired().HasMaxLength(50);
            Pedido.Property(p => p.Estado).IsRequired().HasMaxLength(12);

            Pedido.HasData(listaDb.listPedido());
        });

        modelBuilder.Entity<CadetesPedido>(CP =>
        {
            CP.ToTable("cadetePedido");
            CP.HasKey(CC => CC.id);
            CP.Property(CC => CC.id).IsRequired().ValueGeneratedOnAdd();

            CP.HasOne(c => c.Cadete).
            WithMany(cp => cp.Cadp).HasForeignKey(c => c.userForeingKey)
            .OnDelete(DeleteBehavior.Restrict);

            CP.HasOne(p => p.Pedido)
            .WithOne(cp => cp.Cadp)
            .HasForeignKey<CadetesPedido>(p => p.pedidoForeingKey)
            .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Historial>(CC =>
        {
            CC.ToTable("historial");
            CC.HasKey(CC => CC.id);
            CC.Property(CC => CC.id).IsRequired().ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Calificacion>(Calificacion =>
        {
            Calificacion.ToTable("califiacacion");
            Calificacion.HasKey(p => p.Id);
            Calificacion.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            Calificacion.Property(p => p.valor).HasDefaultValue(0);

            Calificacion.HasOne(us => us.User).WithOne(p => p.Calificacion)
            .HasForeignKey<Calificacion>(p => p.userForeiKey)
            .OnDelete(DeleteBehavior.Cascade);

        });

        modelBuilder.Entity<Articulo>(art =>
        {
            art.ToTable("articulo");
            art.HasKey(p => p.Id);
            art.Property(art => art.Id).IsRequired().ValueGeneratedOnAdd();
            art.Ignore(art => art.categoriaForeiKey);

            art.Property(art => art.Name).HasMaxLength(150);
            art.Property(art => art.descripcion).HasMaxLength(250);
            art.Property(art => art.descripcion).IsRequired(false);
            art.Property(art => art.Price).HasColumnType("decimal(18,2)");


            art.HasMany(art => art.ArticuloCategoria)
            .WithOne(art => art.Articulo).HasForeignKey(art => art.Id);

            art.HasData(listaDb2.ListArticulos());

        });

        modelBuilder.Entity<Categoria>(cat =>
        {
            cat.ToTable("categoria");
            cat.HasKey(p => p.Id);
            cat.Property(cat => cat.Id).IsRequired().ValueGeneratedOnAdd();

            cat.Property(cat => cat.Name).IsRequired().HasMaxLength(20);
            cat.HasIndex(cat => cat.Name).IsUnique();

            cat.HasData(listaDb2.ListCategorias());
        });

        modelBuilder.Entity<ArticuloCategoria>(AC =>
        {
            AC.ToTable("articuloCategoria");
            AC.HasKey(p => p.Id);
            AC.Property(AC => AC.Id).IsRequired().ValueGeneratedOnAdd();

            AC.HasOne(p => p.Articulo)
            .WithMany(p => p.ArticuloCategoria)
            .HasForeignKey(ac => ac.articuloForeiKey)
            .OnDelete(DeleteBehavior.Cascade);

            AC.HasOne(p => p.Categoria)
            .WithMany(p => p.ArticuloCategoria)
            .HasForeignKey(ac => ac.categoriaForeiKey)
            .OnDelete(DeleteBehavior.Cascade);

            AC.HasData(listaDb2.ListaArtC());

        });

        modelBuilder.Entity<Archivo>(file =>
        {
            file.ToTable("archivo");
            file.HasKey(p => p.Id);
            file.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            file.Property(p => p.Name).IsRequired().HasMaxLength(100);
            file.Property(p => p.Foto).IsRequired().HasMaxLength(100);

            file.HasOne(p => p.articulo)
            .WithMany(p => p.archivos)
            .HasForeignKey(file => file.articulolForeiKey)
            .OnDelete(DeleteBehavior.Cascade);

        });

        modelBuilder.Entity<ArchivoPerfil>(file =>
        {
            file.ToTable("archivoPerfil");
            file.HasKey(p => p.Id);
            file.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            file.Property(p => p.Name).IsRequired().HasMaxLength(100);
            file.Property(p => p.Foto).IsRequired().HasMaxLength(100);


            file.HasOne(p => p.perfil)
            .WithOne(p => p.archivo)
            .HasForeignKey<ArchivoPerfil>(p => p.perfilForeiKey)
            .OnDelete(DeleteBehavior.Cascade);
        });
    }

}
