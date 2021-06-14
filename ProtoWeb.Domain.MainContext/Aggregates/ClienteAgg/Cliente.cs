using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProtoWeb.Domain.MainContext.Aggregates.ClienteAgg
{
    public class Cliente
    {
        public Cliente()
        {
            Activo = true;
            FechaRegistro = DateTime.Now;
        }
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        [Column(TypeName = "varchar")]
        public string Nombres { get; set; }

        [Required]
        [MaxLength(250)]
        [Column(TypeName = "varchar")]
        public string Apellidos { get; set; }

        [Required]
        [MaxLength(250)]
        [Column(TypeName = "varchar")]
        public string Correo { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? FechaNacimiento { get; set; }

        [MaxLength(800)]
        [Column(TypeName = "varchar")]
        public string Direccion { get; set; }

        [Required]
        public bool Activo { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime FechaRegistro { get; set; }

        public void Crear(Cliente item)
        {
            FechaRegistro = new DateTime();
        }
        public void Modificar(Cliente item)
        {
            Nombres = item.Nombres;
            Apellidos = item.Apellidos;
            Correo = item.Correo;
            Direccion = item.Direccion;
            FechaNacimiento = item.FechaNacimiento;
            Activo = item.Activo;
        }
    }
}
