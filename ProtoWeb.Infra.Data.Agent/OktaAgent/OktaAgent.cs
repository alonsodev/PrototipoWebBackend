using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProtoWeb.Infra.Data.Agent.OktaAgent
{
    public class OktaAgent : IOktaAgent
    {
        readonly string _oktaDomain;
        readonly string _oktaApiToken;

        public OktaAgent(
            string oktaDomain,
            string oktaApiToken)
        {
            _oktaApiToken = oktaApiToken;
            _oktaDomain = oktaDomain;
        }

        public List<OktaUser> ObtenerUsuarios(string filtro, int top)
        {
            var apiUrl = $"{_oktaDomain}/api/v1/users?q={filtro}&limit={top}";
            var client = new RestClient(apiUrl);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"SSWS {_oktaApiToken}");
            IRestResponse response = client.Execute(request);
            return JsonConvert.DeserializeObject<List<OktaUser>>(response.Content);
        }

        public OktaUser ObtenerUsuarioPorLogin(string login)
        {
            var apiUrl = $"{_oktaDomain}/api/v1/users/{login}";
            var client = new RestClient(apiUrl);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"SSWS {_oktaApiToken}");
            IRestResponse response = client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception($"{response.Content}{Environment.NewLine}{response.ErrorMessage}");
            return JsonConvert.DeserializeObject<OktaUser>(response.Content);
        }
    }
}
