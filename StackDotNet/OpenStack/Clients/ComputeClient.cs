using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using StackDotNet.OpenStack.Models.Compute;
using Newtonsoft.Json;

namespace StackDotNet.OpenStack.Clients
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

        #region Servers

        public async Task<List<Server>> ListServers()
        {
            HttpResponseMessage response = await Client.GetAsync(BaseUrl + "/servers");
            response.EnsureSuccessStatusCode();
            var response_body = await response.Content.ReadAsStringAsync();
            ListServersResponse servers_response = JsonConvert.DeserializeObject<ListServersResponse>(response_body);
            return servers_response.Servers;
        }

        public async Task<List<Server>> ListServersDetailed()
        {
            HttpResponseMessage response = await Client.GetAsync(BaseUrl + "/servers/detail");
            response.EnsureSuccessStatusCode();
            var response_body = await response.Content.ReadAsStringAsync();
            ListServersResponse servers_response = JsonConvert.DeserializeObject<ListServersResponse>(response_body);
            return servers_response.Servers;
        }

        public async Task<Server> GetServer(string serverId)
        {
            HttpResponseMessage response = await Client.GetAsync(BaseUrl + "/servers/" + serverId);
            response.EnsureSuccessStatusCode();
            var response_body = await response.Content.ReadAsStringAsync();
            GetServerResponse server_response = JsonConvert.DeserializeObject<GetServerResponse>(response_body);
            return server_response.Server;
        }

        public async Task DeleteServer(string serverId)
        {
            HttpResponseMessage response = await Client.DeleteAsync(BaseUrl + "/servers/" + serverId);
            response.EnsureSuccessStatusCode();
        }

        public async Task<Addresses> ListServerAddresses(string serverId)
        {
            HttpResponseMessage response = await Client.GetAsync(BaseUrl + "/servers/" + serverId + "/ips");
            response.EnsureSuccessStatusCode();
            var response_body = await response.Content.ReadAsStringAsync();
            ListAddressesResponse addresses_response = JsonConvert.DeserializeObject<ListAddressesResponse>(response_body);
            return addresses_response.Addresses;
        }

        public async Task<Server> CreateServer(string name, string imageId, string flavorId)
        {

        }

        public async Task<Server> UpdateServer(string name, string accessIPv4, string accessIPv6)
        {
            
        }

        public async void GetServerMetadata(string serverId)
        {

        }

        public async void SetServerMetadata(string serverId)
        {

        }

        public async void UpdateServerMetadata(string serverId)
        {

        }

        public async void GetServerMetadataItem(string serverId)
        {

        }

        public async void SetServerMetadataItem(string serverId)
        {

        }

        public async void DeleteServerMetadataItem(string serverId)
        {

        }

        #endregion

        #region Flavors
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

        #endregion

        #region Images

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

        #endregion

    }
}
