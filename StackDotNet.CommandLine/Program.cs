using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using StackDotNet.Clients;
using StackDotNet.Models.Compute;
using StackDotNet.Models.Identity;
using StackDotNet.CommandLine.Properties;

namespace StackDotNet.CommandLine
{

    class Program
    {
        static void Main(string[] args)
        {
            var identityClient = new IdentityClient(Resources.authEndpoint);
            var access_response = identityClient.Authenticate(Resources.username, Resources.password, Resources.username);
            var access = access_response.Result;
            var computeClient = new ComputeClient(access.GetEndpoint("nova", "RegionOne").publicURL, access.token.id);
            var servers = computeClient.ListServers().Result;
            var server = computeClient.GetServer(servers[0].Id).Result;
            Console.WriteLine(server);
            Console.WriteLine();


        }
    }
}
