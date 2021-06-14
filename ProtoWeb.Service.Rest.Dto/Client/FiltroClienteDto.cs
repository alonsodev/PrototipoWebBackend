using System;
using System.Collections.Generic;
using System.Text;

namespace ProtoWeb.Service.Rest.Dto.Cliente
{
    public class FiltroClienteDto
    {
        public string BuscarPor { get; set; }
        public bool? Estado { get; set; }
        public int Pagina { get; set; }
        public int Tamanio { get; set; }

    }
}
