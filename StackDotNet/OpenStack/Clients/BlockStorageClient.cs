using Newtonsoft.Json;
using StackDotNet.OpenStack.Models.BlockStorage;
using System.Collections.Generic;
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
            var response = await Client.GetAsync($"{BaseUrl}/volumes");
            var responseBody = await response.Content.ReadAsStringAsync();
            var volumesResponse = JsonConvert.DeserializeObject<ListVolumesResponse>(responseBody);
            return volumesResponse.Volumes;
        }

        public async Task<Volume> CreateVolume(int size, string volumeType, string imageId, string name)
        {
            var requestBody = new CreateVolumeRequest(size, volumeType, imageId, name);
            var content = JsonConvert.SerializeObject(requestBody);
            var request = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await Client.PostAsync($"{BaseUrl}/volumes", request);
            var responseBody = await response.Content.ReadAsStringAsync();
            var volumeResponse = JsonConvert.DeserializeObject<VolumeResponse>(responseBody);
            return volumeResponse.Volume;
        }

        public async Task<Volume> GetVolume(string volumeId)
        {
            var response = await Client.GetAsync($"{BaseUrl}/volumes/{volumeId}");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var volumeResponse = JsonConvert.DeserializeObject<VolumeResponse>(responseBody);
            return volumeResponse.Volume;
        }

        public async Task DeleteVolume(string volumeId)
        {
            var response = await Client.DeleteAsync($"{BaseUrl}/volumes/{volumeId}");
            response.EnsureSuccessStatusCode();
        }

    }
}
