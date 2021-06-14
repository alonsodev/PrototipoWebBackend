using System;
using System.Collections.Generic;
using System.Text;

namespace ProtoWeb.Infra.CrossCutting.Net.Constantes
{
    public static class ConstantesDb
    {
        #region Parametros 
        public static class Parametro
        {
            public const string NivelAcceso = "NSAS";
            public const string CategoriaPlanificacionAnual = "CPAS";
            public const string TipoEstrategiaEvaluacionMonitoreo = "EEMO";
        }
        #endregion

        #region Parametros Valor
        public static class EstadoGenerico
        {
            public const string Activo = "ESGE0001";
            public const string Inactivo = "ESGE0002";
        }
        public static class RespuestaCierrePqr
        {
            public const string Conforme = "REQR0001";
            public const string NoConforme = "REQR0002";
        }
        public static class EstadoPqr
        {
            public const string PreRegistro = "EPQR0001";
            public const string Proceso = "EPQR0002";
            public const string Cerrado = "EPQR0003";
        }

        public static class TipoCompromisoObligacion
        {
            public const string Compromiso = "TICO0001";
        }

        public static class PeriodicidadCompromisoObligacion
        {
            public const string NoAplica = "PECO0004";
        }

        public static class MotivoCompromisoObligacion
        {
            public const string Otro = "MOCO0001";
        }

        public static class PlazoCompromisoObligacion
        {
            public const string NoAplica = "PACO0006";
        }

        public static class CompromisoObligacion
        {
            public const string EstadoVigente = "ESCO0001";
            public const string EstadoFinalizado = "ESCO0002";
            public const string EstadoCancelado = "ESCO0003";
        }

        public static class Perfil
        {
            public const int Generico = 10;
            public const int Administrador = 1;
        }

        public static class EstadoActa
        {
            public const string Borrador = "ESAC0001";
            public const string ActaGenerada = "ESAC0002";
        }

        public static class EstadoPlanificacion
        {
            public const string Borrador = "ESPL0001";
            public const string EnAprobacion = "ESPL0002";
            public const string EnAprobacionAS = "ESPL0003";
            public const string EnAprobacionVP = "ESPL0004";
            public const string EnAprobacionSCOM = "ESPL0005";
            public const string Observado = "ESPL0006";
            public const string Aprobado = "ESPL0007";
        }

        public static class EstadoTarea
        {
            public const string Pendiente = "ESTA0001";
            public const string EnAprobacion = "ESTA0002";
            public const string Finalizado = "ESTA0003";
            public const string Cancelado = "ESTA0004";
        }

        public static class EstadoTareo
        {
            public const string Abierto = "TAEO0001";
            public const string Cerrado = "TAEO0002";
        }


        public static class TipoTarea
        {
            public const string Actividad = "TITA0001";
            public const string Actas = "TITA0002";
            public const string Administrativa = "TITA0003";
        }

        public static class CategoriaTarea
        {
            public const string RelacionamientoSocial = "CATA0001";
            public const string ActaReunion = "CATA0002";
            public const string Administrativa = "CATA0003";
        }

        public static class EstadoProgramaAnualActividad
        {
            public const string EnProceso = "EAPA0001";
            public const string EnAprobacion = "EAPA0004";
            public const string Observado = "EAPA0005";
            public const string Cancelado = "EAPA0002";
            public const string Finalizado = "EAPA0003";
            public const string Anulado = "EAPA0006";
        }

        public static class EstadoProgramaAnualActividadDesembolso
        {
            public const string EnAprobacion = "EPAD0001";
            public const string Observado = "EPAD0002";
            public const string Aprobado = "EPAD0003";
            public const string Anulado = "EPAD0004";
            public const string Cancelado = "EPAD0005";
        }

        public static class EstadoProgramaAnualActividadPaso
        {
            public const string Pendiente = "EPAP0001";
            public const string Aprobado = "EPAP0002";
            public const string Anulado = "EPAP0003";
        }


        public static class EstadoProgramaAnualActividadDesembolsoPaso
        {
            public const string Pendiente = "EPDP0001";
            public const string Aprobado = "EPDP0002";
            public const string Anulado = "EPDP0003";
        }

        public static class EstrategiaEvaluacionMonitoreo
        {
            public const string EFICACIA = "EEMO0001";
            public const string EFICIENCIA = "EEMO0002";
            public const string ECONOMIA = "EEMO0003";
        }

        public static class NivelAcceso
        {
            public const string SIN_ACCESO = "NSAS0001";
            public const string SOLO_LECTURA = "NSAS0002";
            public const string COLABORACION = "NSAS0003";
            public const string CONTROL_TOTAL = "NSAS0004";
        };

        public static class Permisos
        {
            public const string STAKEHOLDERS = "ENSO0001";
            public const string HECHOS_RELEVANTES = "ENSO0003";
            public const string ZONA_DE_INFLUENCIA = "ENSO0002";
            public const string UBICACIONES_RELEVANTES = "ENSO0004";

            public const string USUARIOS = "GEAD0001";
            public const string PERFILES = "GEAD0002";
            public const string PARAMETROS_DEL_SISTEMA = "GEAD0003";
            public const string UNIDADES_OPERATIVAS = "GEAD0004";

            public const string ACTAS = "RESO0001";
            public const string PQR = "RESO0002";
            public const string TAREAS = "SEDA0003";
            public const string PLANIFICACION = "INSO0001";

            public const string COMPROMISOS_OBLIGACIONES = "ENSO0005";

            public const string RIESGOS = "RISO0001";
            public const string LECCIONES_APRENDIDAS = "RISO0002";
            public const string ACTIVIDADES_SEGUIMIENTO = "SEDA0002";
        }

        public static class PermisosAdicionales
        {
            //Planificacion
            public const string ElaboradorDePlan = "INSO0101";
            public const string AprobadorDePlanNivelGerenciaAS = "INSO0102";
            public const string AprobadorDePlanNivelVP = "INSO0103";
            public const string AprobadorNivelDeResponsableCorporativo = "INSO0104";
            public const string AprobadorNivelDeESCON = "INSO0105";
            public const string AlertaNuevoRiesgoSocial = "RISO0101";
            public const string ResponsableSeguimientoActividades = "RESO0101";
            public const string AlertaTrabajoEnFeriado = "ATEF0101";
        }

        public static class TipoEntidad
        {
            public const string Stakeholder = "TDEN0001";
            public const string Representante = "TDEN0002";
            public const string Persona = "TDEN0003";
            public const string Archivo = "TDEN0004";
            public const string StakeholderDocumento = "TDEN0005";
            public const string NivelInteres = "TDEN0006";
            public const string TemaInteres = "TDEN0007";
            public const string LineaBase = "TDEN0008";
            public const string ZonaInfluencia = "TDEN0009";
            public const string HechoRelevante = "TDEN0010";
            public const string UbicacionRelevante = "TDEN0011";
            public const string CompromisoObligacion = "TDEN0014";
            public const string Acta = "TDEN0013";
            public const string Pqr = "TDEN0012";
            public const string PqrCierre = "TDEN0015";
            public const string PqrCierreRespuesta = "TDEN0016";
            public const string PlanificacionAnual = "TDEN0017";
            public const string ProgramaAnualActividad = "TDEN0018";
            public const string ProgramaAnualActividadDesembolso = "TDEN0028";
            public const string ProgramaAnualActividadDesembolsoPaso = "TDEN0029";
            public const string ProgramaAnualActividadPaso = "TDEN0026";
            public const string ProgramaAnual = "TDEN0019";
            public const string ZonaInfluenciaAutoridad = "TDEN0020";
            public const string ZonaInfluenciaFestividad = "TDEN0021";
            public const string Tarea = "TDEN0022";
            public const string TareaAvanceEjecucion = "TDEN0025";

            public const string ZonaOperativa = "TDEN0023";
            public const string Riesgo = "TDEN0024";
            public const string LeccionAprendida = "TDEN0027";
        }

        public static readonly Dictionary<string, string> DiccionarioTipoEntidad = new Dictionary<string, string>
        {
            { TipoEntidad.Stakeholder, "Stakeholder" },
            { TipoEntidad.Representante, "Representante" },
            { TipoEntidad.Persona, "Persona" },
            { TipoEntidad.Archivo, "Archivo" },
            { TipoEntidad.StakeholderDocumento, "Documento Stakeholder" },
            { TipoEntidad.NivelInteres, "Nivel de Interes" },
            { TipoEntidad.LineaBase, "Linea Base" },
            { TipoEntidad.ZonaInfluencia, "Zona de Influencia" },
            { TipoEntidad.HechoRelevante, "Hecho Relevante" },
            { TipoEntidad.UbicacionRelevante, "Ubicacion Relevante" },
            { TipoEntidad.CompromisoObligacion, "Compromiso u Obligacion" },
            { TipoEntidad.Acta, "Acta" },
            { TipoEntidad.Pqr, "PQR" },
            { TipoEntidad.PqrCierre, "Cierre PQR" },
            { TipoEntidad.PqrCierreRespuesta, "Cierre Respuesta PQR" },
            { TipoEntidad.PlanificacionAnual, "Planificacion Anual" },
            { TipoEntidad.ProgramaAnualActividadDesembolso, "Programa Anual Actividad Desembolso" },
            { TipoEntidad.ProgramaAnualActividadDesembolsoPaso, "Programa Anual Actividad Desembolso Paso" },
            { TipoEntidad.ProgramaAnualActividadPaso, "Programa Anual Actividad Paso" },
            { TipoEntidad.ProgramaAnual, "Programa Anual" },
            { TipoEntidad.ZonaInfluenciaAutoridad, "Autoridad Zona Influencia" },
            { TipoEntidad.ZonaInfluenciaFestividad, "Festividad Zona Influencia" },
            { TipoEntidad.Tarea, "Tarea" },
            { TipoEntidad.TareaAvanceEjecucion, "Tarea Avance Ejecucion" },
            { TipoEntidad.ZonaOperativa, "Zona Operativa" },
            { TipoEntidad.Riesgo, "Riesgo" },
            { TipoEntidad.LeccionAprendida, "Leccion Aprendida" }
        };

        public static class FuenteInformacion
        {
            public const string Publico = "FUIN0001";
            public const string Privado = "FUIN0002";
        }

        public static class VariacionCriticidadRiesgo
        {
            public const string Nuevo = "N";
            public const string Aumenta = "A";
            public const string Disminuye = "D";
            public const string Mantiene = "M";
        }

        public static class ArchivoRepresentante
        {
            public const string AutorizacionTratamientoDatos = "TARE0001";
            public const string Fotografia = "TARE0002";
            public const string SustentoInformacionPublica = "TARE0003";
        }

        public static class ArchivoHechoRelevante
        {
            public const string Imagen = "AHRE0001";
            public const string Archivo = "AHRE0002";
        }

        public static class ArchivoPlanificacionAnual
        {
            public const string EvidenciaAprobacion = "APAN0001";            
        }

        public static class ArchivoActa
        {
            public const string Archivo = "ARAC0001";
            public const string ActaPdf = "ARAC0002";
        }

        public static class ArchivoUbicacionRelevante
        {
            public const string Icono = "AURE0001";
            public const string Imagen = "AURE0002";
        }

        public static class ArchivoPqr
        {
            public const string AdjuntoDatosGenerales = "ARPQ0001";
            public const string AdjuntoDatosGestion = "ARPQ0002";
        }

        public static class ArchivoTarea
        {
            public const string Archivo = "ARTA0001";
        }

        public static class ArchivoTareaEjecucion
        {
            public const string Archivo = "ARTE0001";
        }

        public static class ArchivoPqrCierre
        {
            public const string Archivo = "APQC0001";
        }

        public static class ArchivoProgramaActividadPasoAprobar
        {
            public const string Archivo = "APAA0001";
        }

        public static class ArchivoProgramaActividadDesembolsoPasoAprobar
        {
            public const string Archivo = "APDP0001";
        }

        public static class CompromisoObligacionArchivo
        {
            public const string EstadoCancelar = "ACOB0001";
            public const string EstadoFinalizar = "ACOB0002";
            public const string DetalleAdjunto = "ACOB0003";
        }

        public static class ArchivoPqrCierreRespuesta
        {
            public const string Archivo = "APCR0001";
        }

        public static class ArchivoZonaOperativa
        {
            public const string Imagen = "ARZO0001";
        }

        public static class ArchivoRiesgo
        {
            public const string Archivo = "ARRI0001";
        }

        public static class CantidadDiasUtiles
        {
            public const string AtencionPqr = "CDUF0001";
        }

        public static class DiasPreviosParaAlertaVencimiento
        {
            public const string Tareas = "ALVE0001";
        }

        public static class AlertasBasadasEn
        {
            public const string DiasHabiles = "ALBE0001";
            public const string DiasCalendario = "ALBE0002";
        }
        

        public static class FormatoNumero
        {
            public const string ReportePlanInversionSocial = "RPFN0001";
        }
        #endregion

        #region Usuarios
        public static class Usuarios
        {
            public const string DefaultAdminUserName = "admin";
            private const string DefaultAdminUserId = "85437A8A-54B3-48AA-8B86-2F7800006C3F";
            public static Guid GetDefaultAdminUserId()
            {
                return Guid.Parse(DefaultAdminUserId);
            }
        }
        public static class Clientes
        {
            public const string DefaultAdminCuentaContrato = "20180516647";
            private const string DefaultAdminUserId = "95437A8A-54B3-48AA-8B86-2F7800006C3F";
            public static Guid GetDefaultAdminUserId()
            {
                return Guid.Parse(DefaultAdminUserId);
            }
            public static string GetDefaultAdminCuentaContrato()
            {
                return DefaultAdminCuentaContrato;
            }
        }
        #endregion

        private static readonly Dictionary<int, string> DiccionarioMeses
            = new Dictionary<int, string>
        {
            { 1, "Enero" },
            { 2, "Febrero" },
            { 3, "Marzo" },
            { 4, "Abril" },
            { 5, "Mayo" },
            { 6, "Junio" },
            { 7, "Julio" },
            { 8, "Agosto" },
            { 9, "Septiembre" },
            { 10, "Octubre" },
            { 11, "Noviembre" },
            { 12, "Diciembre" }
        };

        public static Dictionary<int, string> Meses()
        { 
            return DiccionarioMeses;
        }

}
}
