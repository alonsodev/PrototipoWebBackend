using System;
using System.Collections.Generic;
using System.Text;

namespace ProtoWeb.Domain.MainContext.Aggregates.ClienteAgg
{
    public class FiltroCliente
    {
        public String BuscarPor { get; set; }
        public int Pagina { get; set; }
        public int Tamanio { get; set; }
        public bool? Estado { get; set; }
    }
}
