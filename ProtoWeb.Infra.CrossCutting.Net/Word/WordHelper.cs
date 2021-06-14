using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using ProtoWeb.Infra.CrossCutting.Net.Word.Modelo;

namespace ProtoWeb.Infra.CrossCutting.Net.Word
{
    public class WordHelper : IWordHelper
    {
        private string RutaFileServer { get; set; }
        private string RutaApi { get; set; }

        public WordHelper(
            string rutaFileServer,
            string rutaApi)
        {
            RutaFileServer = rutaFileServer;
            RutaApi = rutaApi;
        }

        public void ReemplezarValores(string wordPath, Dictionary<string, string> valores)
        {            
            LlenarDatosEstaticos(wordPath, valores);
        }

        public void EliminarTabla(string filepath, string tagName)
        {
            using (WordprocessingDocument doc = WordprocessingDocument.Open(filepath, true))
            {
                var mainDocument = doc.MainDocumentPart;
                foreach (var stdblock in mainDocument.Document.Descendants())
                {
                    var nodoTag = BuscarNodoPorTag(stdblock, tagName);
                    if (nodoTag != null)
                    {
                        var tablaPadre = nodoTag.Ancestors<Table>().FirstOrDefault();
                        if (tablaPadre != null)
                        {
                            var contenedor = tablaPadre.Parent;
                            contenedor.RemoveChild(tablaPadre);
                            return;
                        }
                    }
                }
            }
        }

        public OpenXmlElement BuscarNodoPorTag(OpenXmlElement elemento, string tagName)
        {
            if (elemento.GetType() == typeof(Tag))
            {
                var tag = (Tag)elemento;
                var value = tag.Val.Value;
                if (value == tagName)
                    return elemento;
                foreach (var block in elemento.Descendants())
                {
                    var nodo = BuscarNodoPorTag(block, tagName);
                    if (nodo != null) return nodo;
                }                
            }
            else
            {
                foreach (var block in elemento.Descendants())
                {
                    var nodo = BuscarNodoPorTag(block, tagName);
                    if (nodo != null) return nodo;
                }
            }
            return null;
        }        

        public string ConstruirDocumentoTemporal(string wordPath)
        {
            var documentoNuevo = $"{RutaFileServer}\\{Guid.NewGuid()}.docx";
            var contenidoArchivo = File.ReadAllBytes($"{RutaApi}\\{wordPath}.docx");
            File.WriteAllBytes(documentoNuevo, contenidoArchivo);
            return documentoNuevo;
        }

        public void ContruirTabla(string wordPath, string tagName, string[,] contenido)
        {
            using WordprocessingDocument doc = WordprocessingDocument.Open(wordPath, true);
            var mainDocument = doc.MainDocumentPart;
            var itemPorTag = mainDocument.Document.Descendants<Tag>().FirstOrDefault(x => x.Val.Value == tagName);
            if (itemPorTag == null) return;
            var tablaPadre = itemPorTag.Ancestors<Table>().FirstOrDefault();
            if (tablaPadre == null) return;
            var primeraFila = tablaPadre.Descendants<TableRow>().FirstOrDefault(x =>
                x.Descendants<TableCell>().Count() >= contenido.GetLength(1) &&
                x.Descendants<TableCell>().Any(a => a.InnerText.ToLower() == "val"));
            if (primeraFila == null) return;
            var padreFila = primeraFila.Parent;
            if (padreFila == null) return;
            var clonada = (TableRow)primeraFila.Clone();
            padreFila.RemoveChild(primeraFila);
            for (var i = 0; i < contenido.GetLength(0); i++)
            {
                var filaNueva = (TableRow)clonada.Clone();
                var celdas = filaNueva.Descendants<TableCell>().ToList();                
                for (var j = 0; j < celdas.Count; j++)
                {
                    if (j >= contenido.GetLength(1)) 
                        continue;                    
                    var valor = contenido[i, j];
                    var celda = celdas[j];
                    var texto = celda.Descendants<Text>().FirstOrDefault();
                    texto.Text = valor;
                }
                padreFila.AppendChild(filaNueva);
            }
        }

        public void ConstruirTablaDesarrolloActa(string wordPath, string tagName, List<DesarrolloActa> desarrolloActas)
        {
            using WordprocessingDocument doc = WordprocessingDocument.Open(wordPath, true);
            var mainDocument = doc.MainDocumentPart;
            var itemPorTag = mainDocument.Document.Descendants<Tag>().FirstOrDefault(x => x.Val.Value == tagName);
            if (itemPorTag == null) return;
            var tablaPadre = itemPorTag.Ancestors<Table>().FirstOrDefault();
            if (tablaPadre == null) return;
            var primeraFila = tablaPadre.Descendants<TableRow>().FirstOrDefault(x =>                
                x.Descendants<TableCell>().Any(a => a.InnerText.ToLower() == "val"));
            if (primeraFila == null) return;
            var padreFila = primeraFila.Parent;
            if (padreFila == null) return;
            var clonada = (TableRow)primeraFila.Clone();
            padreFila.RemoveChild(primeraFila);
            for (var i = 0; i < desarrolloActas.Count; i++)
            {
                var desarrollo = desarrolloActas[i];
                var filaNueva = (TableRow)clonada.Clone();
                var celdas = filaNueva.Descendants<TableCell>().ToList();
                var celda = celdas[0];
                var texto = celda.Descendants<Text>().FirstOrDefault();
                texto.Text = (i + 1).ToString();

                var celdaContenido = celdas[1];
                LlenarCeldaContenido(celdaContenido, desarrollo);
                padreFila.AppendChild(filaNueva);
            }
        }

        private void LlenarCeldaContenido(TableCell celdaContenido, DesarrolloActa desarrollo)
        {
            var tema = celdaContenido.Descendants<Paragraph>().FirstOrDefault(x =>
                    x.Descendants<Run>().Any(a => a.InnerText.ToLower().Trim() == "tema01"));
            var subtema = celdaContenido.Descendants<Paragraph>().FirstOrDefault(x =>
                x.Descendants<Run>().Any(a => a.InnerText.ToLower().Trim() == "subtema01"));
            var desarrolloP = celdaContenido.Descendants<Paragraph>().FirstOrDefault(x =>
                x.Descendants<Run>().Any(a => a.InnerText.ToLower().Trim() == "desarrollo"));
            var tituloCompromisos = celdaContenido.Descendants<Paragraph>().FirstOrDefault(x =>
                x.Descendants<Run>().Any(a => a.InnerText.ToLower().Trim() == "compromisos:"));
            var detalleComp = celdaContenido.Descendants<Paragraph>().FirstOrDefault(x =>
                x.Descendants<Run>().Any(a => a.InnerText.ToLower().Trim() == "comp"));
            var tituloAcuerdos = celdaContenido.Descendants<Paragraph>().FirstOrDefault(x =>
                x.Descendants<Run>().Any(a => a.InnerText.ToLower().Trim() == "acuerdos:"));
            var detalleAcue = celdaContenido.Descendants<Paragraph>().FirstOrDefault(x =>
                x.Descendants<Run>().Any(a => a.InnerText.ToLower().Trim() == "acue"));
            //Clonar
            var temaClonado = (Paragraph)tema.Clone();
            var subtemaClonado = (Paragraph)subtema.Clone();
            var desarrolloPClonado = (Paragraph)desarrolloP.Clone();
            var tituloCompromisosClonado = (Paragraph)tituloCompromisos.Clone();
            var tituloAcuerdosClonado = (Paragraph)tituloAcuerdos.Clone();
            var detalleCompClonado = (Paragraph)detalleComp.Clone();
            var detalleAcueClonado = (Paragraph)detalleAcue.Clone();
            //Remover
            celdaContenido.RemoveChild(tema);
            celdaContenido.RemoveChild(subtema);
            celdaContenido.RemoveChild(desarrolloP);
            celdaContenido.RemoveChild(tituloCompromisos);
            celdaContenido.RemoveChild(detalleComp);
            celdaContenido.RemoveChild(tituloAcuerdos);
            celdaContenido.RemoveChild(detalleAcue);
            //Llenar información
            temaClonado.Descendants<Text>().FirstOrDefault().Text = desarrollo.Titulo;
            celdaContenido.AppendChild(temaClonado);
            foreach (var sub in desarrollo.SubTemas)
            {
                var nuevoSubTema = (Paragraph)subtemaClonado.Clone();
                var nuevoDesarrolloSub = (Paragraph)desarrolloPClonado.Clone();
                var nuevoTituloCompSub = (Paragraph)tituloCompromisosClonado.Clone();
                var nuevoTituloAcueSub = (Paragraph)tituloAcuerdosClonado.Clone();
                nuevoSubTema.Descendants<Text>().FirstOrDefault().Text = sub.Titulo;
                nuevoDesarrolloSub.Descendants<Text>().FirstOrDefault().Text = sub.Desarrollo;
                celdaContenido.AppendChild(nuevoSubTema);
                celdaContenido.AppendChild(nuevoDesarrolloSub);
                celdaContenido.AppendChild(nuevoTituloCompSub);
                foreach (var comp in sub.Compromisos)
                {
                    var nuevoDetalle = (Paragraph)detalleCompClonado.Clone();
                    nuevoDetalle.Descendants<Text>().FirstOrDefault().Text = comp;
                    celdaContenido.AppendChild(nuevoDetalle);
                }
                celdaContenido.AppendChild(nuevoTituloAcueSub);
                foreach (var comp in sub.Acuerdos)
                {
                    var nuevoDetalle = (Paragraph)detalleAcueClonado.Clone();
                    nuevoDetalle.Descendants<Text>().FirstOrDefault().Text = comp;
                    celdaContenido.AppendChild(nuevoDetalle);
                }
            }            
        }

        public void RepetirTablaFirma(string wordPath, string tagName, bool eliminarOrigen, Dictionary<string, string> valores)
        {
            using WordprocessingDocument doc = WordprocessingDocument.Open(wordPath, true);
            var mainDocument = doc.MainDocumentPart;
            var itemPorTag = mainDocument.Document.Descendants<Tag>().FirstOrDefault(x => x.Val.Value == tagName);
            if (itemPorTag == null) return;
            var tablaPadre = itemPorTag.Ancestors<Table>().FirstOrDefault();
            if (tablaPadre == null) return;
            var contenedor = tablaPadre.Parent;
            var clonTablaPadre = (Table)tablaPadre.Clone();
            if (eliminarOrigen) contenedor.RemoveChild(tablaPadre);
            foreach (var valor in valores)
            {
                var tagKey = valor.Key;
                var texto = valor.Value;
                var nodo = clonTablaPadre.Descendants<Tag>().FirstOrDefault(x => x.Val.Value == tagKey);
                if (nodo == null) continue;
                var padreTagBlock = nodo.Ancestors<SdtBlock>().FirstOrDefault();                
                if (padreTagBlock == null)
                {
                    var padreTagRun = nodo.Ancestors<SdtRun>().FirstOrDefault();
                    if (padreTagRun == null) continue;
                    padreTagRun.Descendants<Text>().ToList().ForEach(x => x.Text = texto.Trim());
                }
                else
                {
                    padreTagBlock.Descendants<Text>().ToList().ForEach(x => x.Text = texto.Trim());
                }                
            }
            contenedor.AppendChild(new Break());
            contenedor.AppendChild(clonTablaPadre);
        }

        #region Métodos privados
        private void LlenarDatosEstaticos(string filepath, Dictionary<string, string> datosEstaticos)
        {
            using (WordprocessingDocument doc = WordprocessingDocument.Open(filepath, true))
            {
                var mainDocument = doc.MainDocumentPart;
                foreach (var stdblock in mainDocument.Document.Descendants())
                {
                    SetPropiedad(stdblock, datosEstaticos);
                }
            }
        }

        private void SetPropiedad(OpenXmlElement elemento, Dictionary<string, string> datosEstaticos)
        {
            var sdtblocks = elemento.Descendants();
            foreach (var sdtrun in sdtblocks)
            {
                if (sdtrun.GetType() == typeof(Paragraph))
                    foreach (var prgrph in sdtrun.Descendants<Paragraph>())
                        SetPropiedad(prgrph, datosEstaticos);
                if (sdtrun.GetType() == typeof(SdtProperties))
                    SetPropiedad(sdtrun, datosEstaticos);
                else
                    foreach (var tag in sdtrun.Descendants<Tag>())
                    {
                        if (datosEstaticos.TryGetValue(tag.Val.Value, out string valor))
                            SetText(sdtrun, tag.Val.Value, valor);
                    }
            }
        }

        private static void SetText(OpenXmlElement sdtblock, string etiqueta, string value)
        {
            var valueSplit = value.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            foreach (var text in sdtblock.Descendants<Text>())
            {
                if (text.Text.Trim() == etiqueta)
                {
                    if (valueSplit.Length > 1)
                    {
                        var run = (Run)text.Parent;
                        if (run == null) continue;
                        run.Descendants<Text>().ToList().ForEach(x => x.Remove());
                        for (var i = 0; i < valueSplit.Length; i++)
                        {
                            var line = valueSplit[i];
                            if (i != 0) run.AppendChild(new Break());
                            run.AppendChild(new Text(line));
                        }                     
                    }
                    else
                    {
                        text.Text = value;
                    }
                }                    
            }                        
        }
        #endregion
    }
}
