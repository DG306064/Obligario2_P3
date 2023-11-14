using LogicaNegocio.ValueObjects;
using LogicaNegocio.RegistrodeCambios;
using LogicaNegocio.Parametros;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.Dominio;

namespace LogicaAccesoDatos
{
    public class EmpresaContext : DbContext
    {
        public DbSet<Ecosistema> Ecosistemas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Amenaza> Amenazas { get; set; }
        public DbSet<Especie> Especies { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<EstadoConservacion> Estados { get; set; }
        public DbSet<Habitat> Habitats { get; set; }
        public DbSet<Parametro> Parametros { get; set; }
        public DbSet<RegistroDeCambios> Registros { get; set; }


        public EmpresaContext(DbContextOptions<EmpresaContext> options) : base(options)
        {

            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Ecosistema>().OwnsOne(eco => eco.Nombre).HasIndex(nom => nom.Value).IsUnique();
            modelBuilder.Entity<Ecosistema>().OwnsOne(eco => eco.Descripcion).HasIndex(des => des.Value).IsUnique();
            modelBuilder.Entity<Especie>().OwnsOne(esp => esp.NombreComun).HasIndex(nomCom => nomCom.Value).IsUnique();
            modelBuilder.Entity<Especie>().OwnsOne(esp => esp.Descripcion).HasIndex(des => des.Value).IsUnique();
            modelBuilder.Entity<EstadoConservacion>().OwnsOne(est => est.Nombre).HasIndex(nom => nom.Value).IsUnique();
            modelBuilder.Entity<Pais>().OwnsOne(pais => pais.Nombre).HasIndex(nom => nom.Value).IsUnique();
            modelBuilder.Entity<Amenaza>().OwnsOne(ame => ame.Descripcion).HasIndex(des => des.Value).IsUnique();
            modelBuilder.Entity<Especie>().HasMany(especie => especie.Habitats).WithOne().OnDelete(DeleteBehavior.NoAction);


           
            base.OnModelCreating(modelBuilder);


        }

       



    }
}
