using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using StackDotNet.Models.Compute;
using StackDotNet.Models.Identity;

namespace StackDotNet.Consoles
{
    public class AuthProvider
    {
        public string BaseURL { get; set; }

        public AuthProvider(string BaseURL)
        {
            this.BaseURL = BaseURL;
        }


        public async Task<string> AuthWithPassword(string username, string password, string tenantName)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            AuthRequest r = new AuthRequest(username, password, tenantName);
            var content = JsonConvert.SerializeObject(r);
            var req = new StringContent(content, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(BaseURL + "/v2.0/tokens", req);
            var resp = await response.Content.ReadAsStringAsync();
            RootObject catalog = JsonConvert.DeserializeObject<RootObject>(resp);
            string token = catalog.access.token.id;
            return token;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string baseURL = "http://23.253.150.194/:5000";
            var provider = new AuthProvider(baseURL);
            var token = provider.AuthWithPassword("admin", "ironic", "admin");

 
        }
    }
}
