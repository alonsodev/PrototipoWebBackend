using DocumentFormat.OpenXml.Packaging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Xml;
using DocumentFormat.OpenXml.Wordprocessing;
using RestSharp;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProtoWeb.Infra.Data.Agent.PdfAgent
{
    public class PdfAgent : IPdfAgent
    {
        public string ServiceUrl { get; set; }

        public PdfAgent(string serviceUrl)
        {
            ServiceUrl = serviceUrl;
        }

        public async Task<string> GetBase64PdfFile(string base64WordFile)
        {
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) => { return true; };
            var client = new HttpClient(handler);
            var json = JsonConvert.SerializeObject(new PdfAgentRequest { Base64File = base64WordFile });
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(ServiceUrl, httpContent);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var serviceResponse = JsonConvert.DeserializeObject<PdfAgentResponse>(responseBody);
            return serviceResponse.Base64Pdf;

            ////var client = new RestClient(ServiceUrl);
            ////client.Timeout = -1;
            ////var request = new RestRequest(Method.POST);
            ////var body = new PdfAgentRequest { Base64File = base64WordFile };
            ////request.AddHeader("Content-Type", "application/json");
            ////request.AddParameter("application/json", JsonConvert.SerializeObject(body), ParameterType.RequestBody);
            ////IRestResponse response = client.Execute(request);
            ////var serviceResponse = JsonConvert.DeserializeObject<PdfAgentResponse>(response.Content);
            ////return serviceResponse.Base64Pdf;
        }

    }
}