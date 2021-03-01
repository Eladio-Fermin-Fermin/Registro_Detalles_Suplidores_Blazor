using Microsoft.EntityFrameworkCore;
using Registro_Detalles_Suplidores_Blazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registro_Detalles_Suplidores_Blazor.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Suplidores> Suplidores { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Ordenes> Ordenes { get; set; }

        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Datos Suplidores...
            modelBuilder.Entity<Suplidores>().HasData(new Suplidores
            {
                SuplidorId = 1,
                Nombres = "Ulises Fermin"
            });

            modelBuilder.Entity<Suplidores>().HasData(new Suplidores
            {
                SuplidorId = 2,
                Nombres = "Jesus Lino"
            });

            modelBuilder.Entity<Suplidores>().HasData(new Suplidores
            {
                SuplidorId = 3,
                Nombres = "Maximo Martes"
            });


            //Productos...
            modelBuilder.Entity<Productos>().HasData(new Productos
            {
                ProductoId = 1,
                Descripcion = "Chocolates",
                Costo = 25,
                Inventario = 255
            });

            modelBuilder.Entity<Productos>().HasData(new Productos
            {
                ProductoId = 2,
                Descripcion = "Coca Cola",
                Costo = 65,
                Inventario = 2545
            });

            modelBuilder.Entity<Productos>().HasData(new Productos
            {
                ProductoId = 3,
                Descripcion = "Pepsi",
                Costo = 95,
                Inventario = 555
            });

            modelBuilder.Entity<Productos>().HasData(new Productos
            {
                ProductoId = 4,
                Descripcion = "Cafe",
                Costo = 25,
                Inventario = 100
            });

        }

    }
}
