using Newtonsoft.Json;
using StackDotNet.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StackDotNet.Clients
{
    public class IdentityClient
    {
        public HttpClient Client { get; set; }
        public string BaseUrl { get; set; }

        public IdentityClient(string baseUrl)
        {
            Client = new HttpClient();
            Client.DefaultRequestHeaders.Add("Accept", "application/json");
            BaseUrl = baseUrl;
        }

        public async Task<Access> Authenticate(string username, string password, string tenantName)
        {

            AuthRequest r = new AuthRequest(username, password, tenantName);
            var content = JsonConvert.SerializeObject(r);
            var req = new StringContent(content, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await Client.PostAsync(BaseUrl + "/v2.0/tokens", req);
            var resp = await response.Content.ReadAsStringAsync();
            RootObject root = JsonConvert.DeserializeObject<RootObject>(resp);
            return root.access;
            
        }
    }
}
