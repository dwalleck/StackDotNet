using Newtonsoft.Json;
using StackDotNet.OpenStack.Models.ObjectStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StackDotNet.OpenStack.Clients
{
    public class ObjectStorageClient
    {
        public HttpClient Client { get; set; }
        public string BaseUrl { get; set; }
        public JsonSerializer Serializer { get; set; }

        public ObjectStorageClient(string baseUrl, string token)
        {
            Client = new HttpClient();
            Client.DefaultRequestHeaders.Add("Accept", "application/json");
            Client.DefaultRequestHeaders.Add("X-Auth-Token", token);
            BaseUrl = baseUrl;
        }

        public async Task<AccountMetadata> GetAccountMetadata()
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Head, BaseUrl);
            HttpResponseMessage response = await Client.SendAsync(request);
            AccountMetadata meta = new AccountMetadata(
                Convert.ToInt32(response.Headers.GetValues("X-Account-Object-Count").FirstOrDefault()),
                Convert.ToInt32(response.Headers.GetValues("X-Account-Object-Count").FirstOrDefault()),
                Convert.ToInt32(response.Headers.GetValues("X-Account-Object-Count").FirstOrDefault()));
            return meta;
        }
    }
}
