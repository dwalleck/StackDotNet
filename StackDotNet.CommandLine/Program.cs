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
            var servers = computeClient.ListServersDetailed().Result;
            var s = computeClient.GetServer(servers[0].Id).Result;
            Console.WriteLine("Number of servers: " + servers.Count);
            var flavors = computeClient.ListFlavorsDetailed().Result;
            var images = computeClient.ListImagesDetailed().Result;

            var totalRam = 0;
            var totalDisk = 0;
            var totalCPUs = 0;

            foreach (Server server in servers)
            {
                var flavor = flavors.Where(f => f.Id == server.Flavor.Id).FirstOrDefault();
                totalRam += flavor.Ram;
                totalDisk += flavor.Disk;
                totalCPUs += flavor.VCPUs;
            }

            Console.WriteLine("Ram used: " + totalRam);
            Console.WriteLine("Disk used: " + totalDisk);
            Console.WriteLine("CPUs used: " + totalCPUs);

            var blockStorageClient = new BlockStorageClient(access.GetEndpoint("cinder", "RegionOne").publicURL, access.token.id);
            var volumes = blockStorageClient.ListVolumes().Result;
            Console.WriteLine("Number of volumes: " + volumes.Count);
            Console.WriteLine();


        }
    }
}
