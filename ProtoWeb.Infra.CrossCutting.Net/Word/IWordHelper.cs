using ProtoWeb.Infra.CrossCutting.Net.Word.Modelo;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProtoWeb.Infra.CrossCutting.Net.Word
{
    public interface IWordHelper
    {
        string ConstruirDocumentoTemporal(string wordPath);
        void ReemplezarValores(string wordPath, Dictionary<string, string> valores);
        void EliminarTabla(string filepath, string tagName);
        void ContruirTabla(string wordPath, string tagName, string[,] contenido);
        void RepetirTablaFirma(string wordPath, string tagName, bool eliminarOrigen, Dictionary<string, string> valores);
        void ConstruirTablaDesarrolloActa(string wordPath, string tagName, List<DesarrolloActa> desarrolloActas);
    }
}
