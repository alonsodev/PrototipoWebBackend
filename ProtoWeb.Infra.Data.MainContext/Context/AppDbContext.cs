using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoWeb.Infra.Data.MainContext.Context.Mapping;
using Microsoft.EntityFrameworkCore;
using ProtoWeb.Domain.MainContext.Aggregates.ClienteAgg;
using ProtoWeb.Infra.CrossCutting.Net.Constantes;
using System.Globalization;

namespace ProtoWeb.Infra.Data.MainContext.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        #region IDbSet Members

        public virtual DbSet<Cliente> Cliente { get; set; }

        #endregion

        #region Model Creating

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteEntityTypeConfiguration());

            #region Clientes por defecto
            modelBuilder.Entity<Cliente>()
                .HasData(
                    new Cliente { Id = 1, Nombres = "José Alonso", Apellidos = "Palacios Castillo", Correo = "alonso.palacios.c@gmail.com", Direccion = "av. siempre viva 235", FechaNacimiento = new DateTime(1987, 01, 20) },
                    new Cliente { Id = 2, Nombres = "Edison Gabriel", Apellidos = "Cuadros Paravecino", Correo = "ecuadros@gmail.com", Direccion = "av. los naranjos 1234", FechaNacimiento = new DateTime(1986, 07, 12) },
                    new Cliente { Id = 3, Nombres = "Mario Eduardo", Apellidos = "Ramirez Gonzales", Correo = "mramirez@gmail.com", Direccion = "av. los planeas 123", FechaNacimiento = new DateTime(1987, 09, 01) },
                    new Cliente { Id = 4, Nombres = "Mario Eduardo 1", Apellidos = "Ramirez Gonzales", Correo = "mramirez1@gmail.com", Direccion = "av. los planeas 124", FechaNacimiento = new DateTime(1987, 09, 01) },
                    new Cliente { Id = 5, Nombres = "Mario Eduardo 2", Apellidos = "Ramirez Gonzales", Correo = "mramirez2@gmail.com", Direccion = "av. los planeas 125", FechaNacimiento = new DateTime(1987, 09, 01) },
                    new Cliente { Id = 6, Nombres = "Mario Eduardo 3", Apellidos = "Ramirez Gonzales", Correo = "mramirez3@gmail.com", Direccion = "av. los planeas 126", FechaNacimiento = new DateTime(1987, 09, 01) },
                    new Cliente { Id = 7, Nombres = "Mario Eduardo 4", Apellidos = "Ramirez Gonzales", Correo = "mramirez4@gmail.com", Direccion = "av. los planeas 127", FechaNacimiento = new DateTime(1987, 09, 01) },
                    new Cliente { Id = 8, Nombres = "Mario Eduardo 5", Apellidos = "Ramirez Gonzales", Correo = "mramirez5@gmail.com", Direccion = "av. los planeas 128", FechaNacimiento = new DateTime(1987, 09, 01) },
                    new Cliente { Id = 9, Nombres = "Mario Eduardo 6", Apellidos = "Ramirez Gonzales", Correo = "mramirez6@gmail.com", Direccion = "av. los planeas 129", FechaNacimiento = new DateTime(1987, 09, 01) },
                    new Cliente { Id = 10, Nombres = "Mario Eduardo 7", Apellidos = "Ramirez Gonzales", Correo = "mramirez7@gmail.com", Direccion = "av. los planeas 130", FechaNacimiento = new DateTime(1987, 09, 01) },
                    new Cliente { Id = 11, Nombres = "Mario Eduardo 8", Apellidos = "Ramirez Gonzales", Correo = "mramirez8@gmail.com", Direccion = "av. los planeas 131", FechaNacimiento = new DateTime(1987, 09, 01) },
                    new Cliente { Id = 12, Nombres = "Mario Eduardo 9", Apellidos = "Ramirez Gonzales", Correo = "mramirez9@gmail.com", Direccion = "av. los planeas 132", FechaNacimiento = new DateTime(1987, 09, 01) }
                    );
            #endregion


            SetNotDeleteCascade(modelBuilder);
        }

        private void SetNotDeleteCascade(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
            .SelectMany(t => t.GetForeignKeys())
            .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);
            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.ClientCascade;
        }

        #endregion
    }
}
