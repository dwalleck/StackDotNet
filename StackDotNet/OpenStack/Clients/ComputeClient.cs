using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using StackDotNet.OpenStack.Models.Compute;
using StackDotNet.OpenStack.Models.Compute.Common;
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

        public async Task<Server> UpdateServer(string serverId, string name, string accessIPv4, string accessIPv6)
        {
            UpdateServerRequest requestBody = new UpdateServerRequest(name, accessIPv4, accessIPv6);
            var content = JsonConvert.SerializeObject(requestBody);
            var serialized_content = new StringContent(content, Encoding.UTF8, "application/json");
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, BaseUrl + "/servers/" + serverId);
            request.Content = serialized_content;
            HttpResponseMessage response = await Client.SendAsync(request);
            var responseBody = await response.Content.ReadAsStringAsync();
            ServerResponse serverResponse = JsonConvert.DeserializeObject<ServerResponse>(responseBody);
            return serverResponse.Server;
        }

        public async Task<Metadata> GetServerMetadata(string serverId)
        {
            HttpResponseMessage response = await Client.GetAsync(BaseUrl + "/servers/" + serverId + "/metadata");
            response.EnsureSuccessStatusCode();
            var response_body = await response.Content.ReadAsStringAsync();
            MetadataTransaction metadata_response = JsonConvert.DeserializeObject<MetadataTransaction>(response_body);
            return metadata_response.Metadata;
        }

        public async Task<Metadata> SetServerMetadata(string serverId, Metadata metadata)
        {
            MetadataTransaction requestBody = new MetadataTransaction(metadata);
            var content = JsonConvert.SerializeObject(requestBody);
            var request = new StringContent(content, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await Client.PostAsync(BaseUrl + "/servers/" + serverId + "/metadata", request);
            var responseBody = await response.Content.ReadAsStringAsync();
            MetadataTransaction metadataResponse = JsonConvert.DeserializeObject<MetadataTransaction>(responseBody);
            return metadataResponse.Metadata;
        }

        public async Task<Metadata> UpdateServerMetadata(string serverId, Metadata metadata)
        {
            MetadataTransaction requestBody = new MetadataTransaction(metadata);
            var content = JsonConvert.SerializeObject(requestBody);
            var serialized_content = new StringContent(content, Encoding.UTF8, "application/json");
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, BaseUrl + "/servers/" + serverId + "/metadata");
            request.Content = serialized_content;
            HttpResponseMessage response = await Client.SendAsync(request);
            var responseBody = await response.Content.ReadAsStringAsync();
            MetadataTransaction metadataResponse = JsonConvert.DeserializeObject<MetadataTransaction>(responseBody);
            return metadataResponse.Metadata;
        }

        public async Task<Metadata> GetServerMetadataItem(string serverId, string key)
        {
            HttpResponseMessage response = await Client.GetAsync(BaseUrl + "/servers/" + serverId + "/metadata/" + key);
            response.EnsureSuccessStatusCode();
            var response_body = await response.Content.ReadAsStringAsync();
            MetadataTransaction metadata_response = JsonConvert.DeserializeObject<MetadataTransaction>(response_body);
            return metadata_response.Metadata;
        }

        public async Task<Metadata> SetServerMetadataItem(string serverId, string key, string value)
        {
            Metadata requestBody = new Metadata()
            {
                {key, value}
            };
            var content = JsonConvert.SerializeObject(requestBody);
            var serialized_content = new StringContent(content, Encoding.UTF8, "application/json");
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, BaseUrl + "/servers/" + serverId + "/metadata/" + key);
            request.Content = serialized_content;
            HttpResponseMessage response = await Client.SendAsync(request);
            var responseBody = await response.Content.ReadAsStringAsync();
            MetadataTransaction metadataResponse = JsonConvert.DeserializeObject<MetadataTransaction>(responseBody);
            return metadataResponse.Metadata;
        }

        public async Task DeleteServerMetadataItem(string serverId, string key)
        {
            HttpResponseMessage response = await Client.DeleteAsync(BaseUrl + "/servers/" + serverId + "/metadata" + key);
            response.EnsureSuccessStatusCode();
        }

        public async Task ChangeServerPassword(string serverId, string newPassword)
        {
            ChangePasswordRequest requestBody = new ChangePasswordRequest(newPassword);
            var content = JsonConvert.SerializeObject(requestBody);
            var request = new StringContent(content, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await Client.PostAsync(BaseUrl + "/servers/" + serverId + "/action", request);
        }

        public async Task RebootServer(string serverId, string type)
        {
            RebootServerRequest requestBody = new RebootServerRequest(type);
            var content = JsonConvert.SerializeObject(requestBody);
            var request = new StringContent(content, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await Client.PostAsync(BaseUrl + "/servers/" + serverId + "/action", request);
        }

        public async Task<Server> RebuildServer(string serverId, string name, string imageId)
        {
            RebuildServerRequest requestBody = new RebuildServerRequest(name, imageId);
            var content = JsonConvert.SerializeObject(requestBody);
            var request = new StringContent(content, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await Client.PostAsync(BaseUrl + "/servers/" + serverId + "/action", request);
            var responseBody = await response.Content.ReadAsStringAsync();
            ServerResponse serverResponse = JsonConvert.DeserializeObject<ServerResponse>(responseBody);
            return serverResponse.Server;
        }

        public async Task ResizeServer(string serverId, string newFlavor)
        {
            ResizeServerRequest requestBody = new ResizeServerRequest(newFlavor);
            var content = JsonConvert.SerializeObject(requestBody);
            var request = new StringContent(content, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await Client.PostAsync(BaseUrl + "/servers/" + serverId + "/action", request);
        }

        public async Task ConfirmServerResize(string serverId)
        {
            ConfirmResizeRequest requestBody = new ConfirmResizeRequest();
            var content = JsonConvert.SerializeObject(requestBody);
            var request = new StringContent(content, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await Client.PostAsync(BaseUrl + "/servers/" + serverId + "/action", request);
        }

        public async Task RevertServerResize(string serverId)
        {
            RevertResizeRequest requestBody = new RevertResizeRequest();
            var content = JsonConvert.SerializeObject(requestBody);
            var request = new StringContent(content, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await Client.PostAsync(BaseUrl + "/servers/" + serverId + "/action", request);
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
            HttpResponseMessage response = await Client.DeleteAsync(BaseUrl + "/images/" + imageId);
            response.EnsureSuccessStatusCode();
        }

        public async Task<Image> GetImage(string imageId)
        {
            HttpResponseMessage response = await Client.GetAsync(BaseUrl + "/images/" + imageId);
            var response_body = await response.Content.ReadAsStringAsync();
            GetImageResponse image_response = JsonConvert.DeserializeObject<GetImageResponse>(response_body);
            return image_response.Image;
        }

        public async Task<Metadata> GetImageMetadata(string imageId)
        {
            HttpResponseMessage response = await Client.GetAsync(BaseUrl + "/images/" + imageId + "/metadata");
            response.EnsureSuccessStatusCode();
            var response_body = await response.Content.ReadAsStringAsync();
            MetadataTransaction metadata_response = JsonConvert.DeserializeObject<MetadataTransaction>(response_body);
            return metadata_response.Metadata;
        }

        public async Task<Metadata> SetImageMetadata(string imageId, Metadata metadata)
        {
            MetadataTransaction requestBody = new MetadataTransaction(metadata);
            var content = JsonConvert.SerializeObject(requestBody);
            var request = new StringContent(content, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await Client.PostAsync(BaseUrl + "/images/" + imageId + "/metadata", request);
            var responseBody = await response.Content.ReadAsStringAsync();
            MetadataTransaction metadataResponse = JsonConvert.DeserializeObject<MetadataTransaction>(responseBody);
            return metadataResponse.Metadata;
        }

        public async Task<Metadata> UpdateImageMetadata(string imageId, Metadata metadata)
        {
            MetadataTransaction requestBody = new MetadataTransaction(metadata);
            var content = JsonConvert.SerializeObject(requestBody);
            var serialized_content = new StringContent(content, Encoding.UTF8, "application/json");
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, BaseUrl + "/images/" + imageId + "/metadata");
            request.Content = serialized_content;
            HttpResponseMessage response = await Client.SendAsync(request);
            var responseBody = await response.Content.ReadAsStringAsync();
            MetadataTransaction metadataResponse = JsonConvert.DeserializeObject<MetadataTransaction>(responseBody);
            return metadataResponse.Metadata;
        }

        public async Task<Metadata> GetImageMetadataItem(string imageId, string key)
        {
            HttpResponseMessage response = await Client.GetAsync(BaseUrl + "/images/" + imageId + "/metadata/" + key);
            response.EnsureSuccessStatusCode();
            var response_body = await response.Content.ReadAsStringAsync();
            MetadataTransaction metadata_response = JsonConvert.DeserializeObject<MetadataTransaction>(response_body);
            return metadata_response.Metadata;
        }

        public async Task<Metadata> SetImageMetadataItem(string imageId, string key, string value)
        {
            Metadata requestBody = new Metadata()
            {
                {key, value}
            };
            var content = JsonConvert.SerializeObject(requestBody);
            var serialized_content = new StringContent(content, Encoding.UTF8, "application/json");
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, BaseUrl + "/images/" + imageId + "/metadata/" + key);
            request.Content = serialized_content;
            HttpResponseMessage response = await Client.SendAsync(request);
            var responseBody = await response.Content.ReadAsStringAsync();
            MetadataTransaction metadataResponse = JsonConvert.DeserializeObject<MetadataTransaction>(responseBody);
            return metadataResponse.Metadata;
        }

        public async Task DeleteImageMetadataItem(string imageId, string key)
        {
            HttpResponseMessage response = await Client.DeleteAsync(BaseUrl + "/images/" + imageId + "/metadata" + key);
            response.EnsureSuccessStatusCode();
        }

        #endregion

    }
}
