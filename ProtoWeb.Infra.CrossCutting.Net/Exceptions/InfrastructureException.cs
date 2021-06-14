using ProtoWeb.Infra.CrossCutting.Net.Constantes;
using System;
using System.Runtime.Serialization;

namespace ProtoWeb.Infra.CrossCutting.Net.Exceptions
{
    public class InfrastructureException : Exception
    {
        public InfrastructureException(Guid idOperacion, string codigo, TipoException tipo, string message, string accion, Exception ex) : base(message, ex)
        {
            Codigo = codigo;
            IdOperacion = idOperacion;
            Tipo = tipo;
            Accion = accion;
        }
        public Guid IdOperacion { get; }
        public TipoException Tipo { get; }
        public string Accion { get; }
        public string Codigo { get; }
        public string Mensaje
        {
            get
            {
                return base.Message;
            }
        }

    }
}
