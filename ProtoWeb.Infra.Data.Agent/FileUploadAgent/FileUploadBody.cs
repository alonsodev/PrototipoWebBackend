using System;
using System.Collections.Generic;
using System.Text;

namespace ProtoWeb.Infra.Data.Agent.FileUploadAgent
{
    public class FileUploadBody
    {
        public string IdEntidad { get; set; }
        public string IdTipoEntidad { get; set; }
        public string Nombre { get; set; }
        public string Extension { get; set; }
        public byte[] Bytes { get; set; }

        public string NombreCompleto
        {
            get
            {
                return $"{Nombre}.{Extension}";
            }
        }
    }
}
