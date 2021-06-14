using System;
using System.Collections.Generic;
using System.Text;

namespace ProtoWeb.Infra.CrossCutting.Net.Constantes
{
    public class ConstantesGenerales
    {
        public static class MODO_BUSQUEDA_PERMISO
        {
            public const string LECTURA = "LECTURA";
            public const string ESCRITURA = "ESCRITURA";
        }

        public static class ORDENAMIENTO
        {
            public const string Ascendente = "asc";
            public const string Descendente = "desc";
        }

        public static class ACTA_CONVOCADO_POR
        {
            public const string Engie = "ENGIE";
            public const string Autoridad = "Autoridad";
            public const string Otro = "Otro";
        }

        public static class ACTA_TIPO_CONVOCADO
        {
            public const string Stakeholder = "Stakeholder";
            public const string Otro = "Otro";
        }

        public static class MOTIVO_COMPROMISO_OBLIGACION
        {
            public const string AcuerdoActaReunion = "Acuerdo de Acta de reunión";
        }

        public static class TIPO_ACTUALIZACION_PQR
        {
            public const string DATOS_GENERALES = "GENERALES";
            public const string DATOS_GESTION = "GESTION";
            public const string TODOS = "TODOS";
        }

        public static class INTEGRACION_SHAREPOINT
        {
            public const string DIRECTORIO_GENERAL = "General";
        }
    }
}
