using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using StackDotNet.OpenStack.Models.Compute;
using StackDotNet.OpenStack.Models.Compute.Requests;
using Newtonsoft.Json;

namespace StackDotNet.OpenStack.Clients
{
    public class ComputeClient : IComputeClient
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
            ServerResponse server_response = JsonConvert.DeserializeObject<ServerResponse>(response_body);
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
            CreateServerRequest requestBody = new CreateServerRequest(name, imageId, flavorId);
            var content = JsonConvert.SerializeObject(requestBody);
            var request = new StringContent(content, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await Client.PostAsync(BaseUrl + "/servers", request);
            var responseBody = await response.Content.ReadAsStringAsync();
            ServerResponse serverResponse = JsonConvert.DeserializeObject<ServerResponse>(responseBody);
            return serverResponse.Server;
        }

        public async Task<Server> UpdateServer(string name, string accessIPv4, string accessIPv6)
        {
            throw new NotImplementedException();
        }

        public async void GetServerMetadata(string serverId)
        {
            throw new NotImplementedException();
        }

        public async void SetServerMetadata(string serverId)
        {
            throw new NotImplementedException();
        }

        public async void UpdateServerMetadata(string serverId)
        {
            throw new NotImplementedException();
        }

        public async void GetServerMetadataItem(string serverId)
        {
            throw new NotImplementedException();
        }

        public async void SetServerMetadataItem(string serverId)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteServerMetadataItem(string serverId)
        {
            throw new NotImplementedException();
        }

        public async Task ChangeServerPassword(string serverId, string newPassword)
        {
            throw new NotImplementedException();
        }

        public async Task RebootServer(string serverId)
        {
            throw new NotImplementedException();
        }

        public async Task<Server> RebuildServer(string serverId)
        {
            throw new NotImplementedException();
        }

        public async Task ResizeServer(string serverId, string newFlavor)
        {
            throw new NotImplementedException();
        }

        public async Task ConfirmServerResize(string serverId)
        {
            throw new NotImplementedException();
        }

        public async Task RevertServerResize(string serverId)
        {
            throw new NotImplementedException();
        }

        public async Task<string> CreateImage(string serverId, string name)
        {
            CreateImageRequest requestBody = new CreateImageRequest(name);
            var content = JsonConvert.SerializeObject(requestBody);
            var request = new StringContent(content, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await Client.PostAsync(BaseUrl + "/servers/" + serverId + "/action", request);

            var imageLocation = response.Headers.GetValues("location").FirstOrDefault();
            var imageId = imageLocation.Split('/').Last();
            return imageId;
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

        public async Task DeleteImage(string imageId)
        {
            throw new NotImplementedException();
        }

        public async Task<Image> GetImage(string imageId)
        {
            HttpResponseMessage response = await Client.GetAsync(BaseUrl + "/images/" + imageId);
            var response_body = await response.Content.ReadAsStringAsync();
            GetImageResponse image_response = JsonConvert.DeserializeObject<GetImageResponse>(response_body);
            return image_response.Image;
        }

        public async void GetImageMetadata(string imageId)
        {
            throw new NotImplementedException();
        }

        public async void SetImageMetadata(string imageId)
        {
            throw new NotImplementedException();
        }

        public async void UpdateImageMetadata(string imageId)
        {
            throw new NotImplementedException();
        }

        public async void GetImageMetadataItem(string imageId)
        {
            throw new NotImplementedException();
        }

        public async void SetImageMetadataItem(string imageId)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteImageMetadataItem(string imageId)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
