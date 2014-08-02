using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using StackDotNet.OpenStack.Clients;
using StackDotNet.OpenStack.Models.Compute;
using StackDotNet.OpenStack.Models.Identity;
using StackDotNet.CommandLine.Properties;
using StackDotNet.ThirdParty.Rackspace.Clients;

namespace StackDotNet.CommandLine
{

    class Program
    {
        static void Main(string[] args)
        {
            //var identityClient = new IdentityClient(Resources.authEndpoint);
            //var access_response = identityClient.Authenticate(Resources.username, Resources.password, Resources.username);

            var identityClient = new CloudIdentityClient("https://identity.api.rackspacecloud.com");
            var access_response = identityClient.Authenticate("qeuser1", "64de43be5b024361b0425196450345a6", "658803");
            var access = access_response.Result;
            //var computeClient = new ComputeClient(access.GetEndpoint("nova", "RegionOne").PublicUrl, access.Token.Id);
            var computeClient = new ComputeClient(access.GetEndpoint("cloudServersOpenStack", "IAD").PublicUrl, access.Token.Id);
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

            var blockStorageClient = new BlockStorageClient(access.GetEndpoint("cloudBlockStorage", "IAD").PublicUrl, access.Token.Id);
            var volumes = blockStorageClient.ListVolumes().Result;
            Console.WriteLine("Number of volumes: " + volumes.Count);

            var objectStorageClient = new ObjectStorageClient(access.GetEndpoint("cloudFiles", "DFW").PublicUrl, access.Token.Id);
            var accountMeta = objectStorageClient.GetAccountMetadata().Result;
            Console.WriteLine(accountMeta.BytesUsed);

            Console.WriteLine();


        }
    }
}
