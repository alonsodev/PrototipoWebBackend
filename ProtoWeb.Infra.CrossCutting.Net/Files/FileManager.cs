using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoWeb.Infra.CrossCutting.Net.Constantes;
using ProtoWeb.Infra.CrossCutting.Net.Exceptions;

namespace ProtoWeb.Infra.CrossCutting.Net.Files
{
    public class FileManager
    {
        public string ChunkPath { get; set; }

        public void SaveChunk(Guid id, byte[] data)
        {
            if (string.IsNullOrWhiteSpace(ChunkPath)) throw new ArgumentNullException("filePath");
            if (data == null) throw new ArgumentNullException("data");

            var fileNamePath = string.Format(@"{0}\{1}", ChunkPath, id);

            using (var fileStream = new FileStream(fileNamePath, FileMode.Append))
            {
                using (var bw = new BinaryWriter(fileStream))
                {
                    bw.Write(data);
                }
            }
        }

        public void SaveChunkIntegraciones(Guid id, byte[] data, string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath)) throw new ArgumentNullException("filePath");
            if (data == null) throw new ArgumentNullException("data");

            var fileNamePath = string.Format(@"{0}\{1}", filePath, id);

            using (var fileStream = new FileStream(fileNamePath, FileMode.Append))
            {
                using (var bw = new BinaryWriter(fileStream))
                {
                    bw.Write(data);
                }
            }
        }

        public void MoveFile(string sourceFileName, string targetFileName)
        {
            if (string.IsNullOrWhiteSpace(sourceFileName)) throw new ArgumentNullException("sourceFileName");
            if (string.IsNullOrWhiteSpace(targetFileName)) throw new ArgumentNullException("targetFileName");

            var origen = string.Format(@"{0}\{1}", ChunkPath, sourceFileName);
            var destino = string.Format(@"{0}\{1}", ChunkPath, targetFileName);

            //FileInfo fileorigen = new FileInfo(origen);
            //FileInfo filedestino = new FileInfo(destino);

            //if (file.Exists)
            //{
            //    File.Move(oldFilename, newFilename);
            //}

            File.Move(origen, destino);
        }

        public void MoveIntegracionesFile(string sourceFileName, string targetFileName, string filePath)
        {
            if (string.IsNullOrWhiteSpace(sourceFileName)) throw new ArgumentNullException("sourceFileName");
            if (string.IsNullOrWhiteSpace(targetFileName)) throw new ArgumentNullException("targetFileName");

            var origen = string.Format(@"{0}\{1}", filePath, sourceFileName);
            var destino = string.Format(@"{0}\{1}", filePath, targetFileName);

            File.Move(origen, destino);
        }

        public string SaveFile(byte[] data, string directorio, string nombre, string extension)
        {
            if (string.IsNullOrWhiteSpace(ChunkPath)) throw new ArgumentNullException("filePath");
            if (data == null) throw new ArgumentNullException("data");

            var id = Guid.NewGuid();
            var Nombrearchivo = $"{id}{nombre}";
            var fileNamePath = string.IsNullOrWhiteSpace(extension) ?
                string.Format(@"{0}\{1}\{2}", ChunkPath, directorio, Nombrearchivo) :
                string.Format(@"{0}\{1}\{2}.{3}", ChunkPath, directorio, Nombrearchivo, extension);

            using (var fileStream = new FileStream(fileNamePath, FileMode.Create))
            {
                using (var bw = new BinaryWriter(fileStream))
                {
                    bw.Write(data);
                }
            }
            return Nombrearchivo;
        }

        public async Task<byte[]> DownloadFileAsBytes(string fileName)
        {
            var filePath = Path.Combine(ChunkPath, fileName);
            if (!File.Exists(filePath)) throw new Exceptions.FileNotFoundException("El archivo no existe");

            byte[] fileAsBytes = null;
            using (var file = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, true))
            {
                fileAsBytes = new byte[file.Length];
                await file.ReadAsync(fileAsBytes, 0, (int)file.Length);
            }
            return fileAsBytes;
        }

        public async Task<byte[]> DownloadFileAsBytesIntegracion(string filePath)
        {
            if (!File.Exists(filePath)) throw new Exceptions.FileNotFoundException("El archivo no existe");

            byte[] fileAsBytes = null;
            using (var file = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, true))
            {
                fileAsBytes = new byte[file.Length];
                await file.ReadAsync(fileAsBytes, 0, (int)file.Length);
            }
            return fileAsBytes;
        }
    }
}
