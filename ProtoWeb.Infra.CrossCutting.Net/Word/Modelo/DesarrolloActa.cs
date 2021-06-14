using System;
using System.Collections.Generic;
using System.Text;

namespace ProtoWeb.Infra.CrossCutting.Net.Word.Modelo
{
    public class DesarrolloActa
    {
        public string Titulo { get; set; }
        public List<DesarrolloActaSubTema> SubTemas { get; set; }
    }

    public class DesarrolloActaSubTema
    {
        public string Titulo { get; set; }
        public string Desarrollo { get; set; }
        public List<string> Compromisos { get; set; }
        public List<string> Acuerdos { get; set; }
    }
}
