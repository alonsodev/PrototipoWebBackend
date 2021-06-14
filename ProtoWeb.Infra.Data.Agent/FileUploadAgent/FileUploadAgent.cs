using ProtoWeb.Infra.CrossCutting.Net.Constantes;
using ProtoWeb.Infra.Data.Agent.FileUploadAgent.Model;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProtoWeb.Infra.Data.Agent.FileUploadAgent
{
    public class FileUploadAgent : IFileUploadAgent
    {
        readonly string _rutaDirectorio;
        readonly string _rutaPublicaDirectorio;

        public FileUploadAgent(
            string rutaDirectorio)
        {
            _rutaDirectorio = rutaDirectorio;
        }

        public async Task SubirArchivoAsync(FileUploadBody archivo)
        {
            var rutaCompletaArchivo = ObtenerNombreCompletoArchivo(archivo);
            await File.WriteAllBytesAsync(rutaCompletaArchivo, archivo.Bytes);
        }

        public void EliminarArchivo(FileUploadBody archivo)
        {
            var rutaCompletaArchivo = ObtenerNombreCompletoArchivo(archivo);
            if (File.Exists(rutaCompletaArchivo))
                File.Delete(rutaCompletaArchivo);
        }

        public byte[] DescargarArchivo(FileUploadBody archivo)
        {
            var rutaCompletaArchivo = ObtenerNombreCompletoArchivo(archivo);
            if (!File.Exists(rutaCompletaArchivo))
                return null;
            return File.ReadAllBytes(rutaCompletaArchivo);
        }

        public string ObtenerNombreCompletoArchivo(FileUploadBody archivo)
        {
            var rutaDirectorioEntidad = ValidarDirectorio(
                archivo.IdEntidad, archivo.IdTipoEntidad);
            var nombreArchivo = $"{archivo.Nombre}.{archivo.Extension}";
            var rutaCompletaArchivo = Path.Combine(rutaDirectorioEntidad, nombreArchivo);
            return rutaCompletaArchivo;
        }

        public string ObtenerRutaPublicaArchivo(
            string idTipoEntidad, int idEntidad, Guid identificador, string extension)
        {
            var rutaPublica = _rutaPublicaDirectorio;
            if (!_rutaPublicaDirectorio.EndsWith("/")) rutaPublica = $"{_rutaPublicaDirectorio}/";
            return $"{rutaPublica}{idTipoEntidad}_{idEntidad}/{identificador}.{extension}";
        }

        private string ValidarDirectorio(string idEntidad, string idTipoEntidad)
        {
            var rutaCompleta = Path.Combine(
                _rutaDirectorio, $"{idTipoEntidad}_{idEntidad}");
            if (Directory.Exists(rutaCompleta)) return rutaCompleta;
            Directory.CreateDirectory(rutaCompleta);
            return rutaCompleta;
        }
    }
}
