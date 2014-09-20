using Newtonsoft.Json;
using StackDotNet.OpenStack.Models.BlockStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StackDotNet.OpenStack.Clients
{
    public class BlockStorageClient
    {
        public HttpClient Client { get; set; }
        public string BaseUrl { get; set; }
        public JsonSerializer Serializer { get; set; }

        public BlockStorageClient(string baseUrl, string token)
        {
            Client = new HttpClient();
            Client.DefaultRequestHeaders.Add("Accept", "application/json");
            Client.DefaultRequestHeaders.Add("X-Auth-Token", token);
            BaseUrl = baseUrl;
        }

        public async Task<List<Volume>> ListVolumes()
        {
            HttpResponseMessage response = await Client.GetAsync(BaseUrl + "/volumes");
            var response_body = await response.Content.ReadAsStringAsync();
            ListVolumesResponse volumes_response = JsonConvert.DeserializeObject<ListVolumesResponse>(response_body);
            return volumes_response.Volumes;
        }

        public async Task<Volume> CreateVolume(int size, string volumeType, string imageId, string name)
        {
            CreateVolumeRequest requestBody = new CreateVolumeRequest(size, volumeType, imageId, name);
            var content = JsonConvert.SerializeObject(requestBody);
            var request = new StringContent(content, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await Client.PostAsync(BaseUrl + "/volumes", request);
            var responseBody = await response.Content.ReadAsStringAsync();
            VolumeResponse volumeResponse = JsonConvert.DeserializeObject<VolumeResponse>(responseBody);
            return volumeResponse.Volume;
        }

        public async Task<Volume> GetVolume(string volumeId)
        {
            HttpResponseMessage response = await Client.GetAsync(BaseUrl + "/volumes/" + volumeId);
            response.EnsureSuccessStatusCode();
            var response_body = await response.Content.ReadAsStringAsync();
            VolumeResponse volume_response = JsonConvert.DeserializeObject<VolumeResponse>(response_body);
            return volume_response.Volume;
        }

        public async Task DeleteVolume(string volumeId)
        {
            HttpResponseMessage response = await Client.DeleteAsync(BaseUrl + "/volumes/" + volumeId);
            response.EnsureSuccessStatusCode();
        }

    }
}
