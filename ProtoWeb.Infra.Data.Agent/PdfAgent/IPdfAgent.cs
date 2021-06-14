using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProtoWeb.Infra.Data.Agent.PdfAgent
{
    public interface IPdfAgent
    {
        Task<string> GetBase64PdfFile(string base64WordFile);
    }
}
