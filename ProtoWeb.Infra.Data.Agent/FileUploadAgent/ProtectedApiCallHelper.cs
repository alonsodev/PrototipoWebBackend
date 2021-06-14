using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ProtoWeb.Infra.Data.Agent.FileUploadAgent
{
    public class ProtectedApiCallHelper
    {
        public ProtectedApiCallHelper(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        protected HttpClient HttpClient { get; private set; }

        public async Task<T> CallWebApiAndProcessResultAsync<T>(string webApiUrl, string accessToken)
        {
            if (string.IsNullOrEmpty(accessToken)) return default;
            var defaultRequestHeaders = HttpClient.DefaultRequestHeaders;
            if (defaultRequestHeaders.Accept == null || !defaultRequestHeaders.Accept.Any(m => m.MediaType == "application/json"))
            {
                HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
            defaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            HttpResponseMessage response = await HttpClient.GetAsync(webApiUrl);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<T>(json);
                return result;
            }
            else
            {
                string content = await response.Content.ReadAsStringAsync();
                throw new Exception(content);
            }                
        }
    }
}
