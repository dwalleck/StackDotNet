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

        public async Task<List<Server>> ListServersDetailed()
        {
            HttpResponseMessage response = await Client.GetAsync(BaseUrl + "/servers/detail");
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

        public async Task<List<Flavor>> ListFlavors()
        {
            HttpResponseMessage response = await Client.GetAsync(BaseUrl + "/flavors");
            var response_body = await response.Content.ReadAsStringAsync();
            ListFlavorsResponse flavors_response = JsonConvert.DeserializeObject<ListFlavorsResponse>(response_body);
            return flavors_response.Flavors;
        }

        public async Task<List<Flavor>> ListFlavorsDetailed()
        {
            HttpResponseMessage response = await Client.GetAsync(BaseUrl + "/flavors/detail");
            var response_body = await response.Content.ReadAsStringAsync();
            ListFlavorsResponse flavors_response = JsonConvert.DeserializeObject<ListFlavorsResponse>(response_body);
            return flavors_response.Flavors;
        }

        public async Task<Flavor> GetFlavor(string flavorId)
        {
            HttpResponseMessage response = await Client.GetAsync(BaseUrl + "/flavors/" + flavorId);
            var response_body = await response.Content.ReadAsStringAsync();
            GetFlavorResponse flavor_response = JsonConvert.DeserializeObject<GetFlavorResponse>(response_body);
            return flavor_response.Flavor;
        }

        public async Task<List<Image>> ListImages()
        {
            HttpResponseMessage response = await Client.GetAsync(BaseUrl + "/images");
            var response_body = await response.Content.ReadAsStringAsync();
            ListImagesResponse images_response = JsonConvert.DeserializeObject<ListImagesResponse>(response_body);
            return images_response.Images;
        }

        public async Task<List<Image>> ListImagesDetailed()
        {
            HttpResponseMessage response = await Client.GetAsync(BaseUrl + "/images/detail");
            var response_body = await response.Content.ReadAsStringAsync();
            ListImagesResponse images_response = JsonConvert.DeserializeObject<ListImagesResponse>(response_body);
            return images_response.Images;
        }

    }
}
