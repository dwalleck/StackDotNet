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

    }
}
