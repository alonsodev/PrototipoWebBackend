using Newtonsoft.Json;
using System.Collections.Generic;

namespace ProtoWeb.Infra.Data.Agent.MailSender
{
    public class MailDto
    {
        /// <summary>
        /// Nombre con el que se muestra el correo origen
        /// </summary>
        public string DeDisplay { get; set; }
        /// <summary>
        /// Lista de correos destinatario con la forma key:correo/value:nombre que se muestra
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Dictionary<string, string> Para { get; set; }
        /// <summary>
        /// Lista de correos de copia conjunta con la forma key:correo/value:nombre que se muestra
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Dictionary<string, string> Cc { get; set; }
        /// <summary>
        /// Asunto del correo
        /// </summary>
        public string Asunto { get; set; }
        /// <summary>
        /// Cuerpo del correo. Puede ser contenido HTML o no
        /// </summary>
        public string Cuerpo { get; set; }
        /// <summary>
        /// Indica si el contenido del correo estan en formato HTML
        /// </summary>
        public bool CuerpoEsHtml { get; set; }

        /// <summary>
        /// Indica si el contenido del correo estan en formato HTML
        /// </summary>
        public List<AttachmentDto> Adjuntos { get; set; }
    }

    public class AttachmentDto
    {
        public byte[] ArchivoAsBytes { get; set; }
        //public string Nombre { get; set; }
        public string MimeType { get; set; }
    }
}
