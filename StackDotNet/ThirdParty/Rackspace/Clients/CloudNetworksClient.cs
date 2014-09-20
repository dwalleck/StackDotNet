using Newtonsoft.Json;
using StackDotNet.ThirdParty.Rackspace.Models.CloudNetworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StackDotNet.ThirdParty.Rackspace.Clients
{
    public class CloudNetworksClient
    {
        public HttpClient Client { get; set; }
        public string BaseUrl { get; set; }
        public JsonSerializer Serializer { get; set; }

        public CloudNetworksClient(string baseUrl, string token)
        {
            Client = new HttpClient();
            Client.DefaultRequestHeaders.Add("Accept", "application/json");
            Client.DefaultRequestHeaders.Add("X-Auth-Token", token);
            BaseUrl = baseUrl;
        }

        public async Task<List<Network>> ListNetworks()
        {
            HttpResponseMessage response = await Client.GetAsync(BaseUrl + "/os-networksv2");
            var response_body = await response.Content.ReadAsStringAsync();
            var networks_response = JsonConvert.DeserializeObject<ListNetworksResponse>(response_body);
            return networks_response.Networks;
        }

        public async Task DeleteNetwork(string networkId)
        {
            HttpResponseMessage response = await Client.DeleteAsync(BaseUrl + "/os-networksv2/" + networkId);
            response.EnsureSuccessStatusCode();
        }

        public async Task<Network> CreateNetwork(string cidr, string label)
        {
            CreateNetworkRequest requestBody = new CreateNetworkRequest(cidr, label);
            var content = JsonConvert.SerializeObject(requestBody);
            var request = new StringContent(content, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await Client.PostAsync(BaseUrl + "/os-networksv2", request);
            var responseBody = await response.Content.ReadAsStringAsync();
            NetworkResponse networkResponse = JsonConvert.DeserializeObject<NetworkResponse>(responseBody);
            return networkResponse.Network;
        }

        public async Task<Network> GetNetwork(string networkId)
        {
            HttpResponseMessage response = await Client.GetAsync(BaseUrl + "/os-networksv2/" + networkId);
            response.EnsureSuccessStatusCode();
            var response_body = await response.Content.ReadAsStringAsync();
            NetworkResponse networkResponse = JsonConvert.DeserializeObject<NetworkResponse>(response_body);
            return networkResponse.Network;
        }
    }
}
