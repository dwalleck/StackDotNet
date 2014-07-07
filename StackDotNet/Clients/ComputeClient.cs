using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using StackDotNet.Models.Compute;
using Newtonsoft.Json;

namespace StackDotNet.Clients
{
    public class ComputeClient
    {
        public HttpClient Client { get; set; }
        public string BaseUrl { get; set; }
        public JsonSerializer Serializer { get; set; }

        public ComputeClient(string baseUrl, string token)
        {
            Client = new HttpClient();
            Client.DefaultRequestHeaders.Add("Accept", "application/json");
            Client.DefaultRequestHeaders.Add("X-Auth-Token", token);
            BaseUrl = baseUrl;
        }

        public async Task<List<Server>> ListServers()
        {
            HttpResponseMessage response = await Client.GetAsync(BaseUrl + "/servers");
            var response_body = await response.Content.ReadAsStringAsync();
            ListServersResponse servers_response = JsonConvert.DeserializeObject<ListServersResponse>(response_body);
            return servers_response.Servers;
        }

        public async Task<Server> GetServer(string serverId)
        {
            HttpResponseMessage response = await Client.GetAsync(BaseUrl + "/servers/" + serverId);
            var response_body = await response.Content.ReadAsStringAsync();
            GetServerResponse server_response = JsonConvert.DeserializeObject<GetServerResponse>(response_body);
            return server_response.Server;
        }

    }
}
