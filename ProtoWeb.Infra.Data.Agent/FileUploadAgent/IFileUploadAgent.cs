using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProtoWeb.Infra.Data.Agent.FileUploadAgent
{
    public interface IFileUploadAgent
    {
        Task SubirArchivoAsync(FileUploadBody archivo);
        void EliminarArchivo(FileUploadBody archivo);
        byte[] DescargarArchivo(FileUploadBody archivo);
        string ObtenerRutaPublicaArchivo(string idTipoEntidad, int idEntidad, Guid identificador, string extension);
    }
}
