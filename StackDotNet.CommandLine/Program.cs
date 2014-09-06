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
using System.Threading;
using StackDotNet.OpenStack.Models.Compute.Common;

namespace StackDotNet.CommandLine
{

    class Program
    {
        static void Main(string[] args)
        {
            var identityClient = new CloudIdentityClient("https://identity.api.rackspacecloud.com");
            var access_response = identityClient.Authenticate("qeuser1", "64de43be5b024361b0425196450345a6", "658803");
            var access = access_response.Result;
            var computeClient = new ComputeClient(access.GetEndpoint("cloudServersOpenStack", "IAD").PublicUrl, access.Token.Id);

            var server = computeClient.CreateServer("csharptest", "ffd597d6-2cc4-4b43-b8f4-b1006715b84e", "performance1-1").Result;

            Console.WriteLine("Created server " + server.Id);

            while (server.Status != "ACTIVE")
            {
                server = computeClient.GetServer(server.Id).Result;
                Console.WriteLine("Status: " + server.Status);
                Console.WriteLine("Progress: " + server.Progress);
                Thread.Sleep(15000);

            }

            Metadata metadata = new Metadata()
            {
                {"key1", "value1"},
                {"key12", "value12"},
            };
            var meta = computeClient.UpdateServerMetadata(server.Id, metadata).Result;

            server = computeClient.GetServer(server.Id).Result;
            var response = computeClient.DeleteServer(server.Id);
            response.Wait();

            /*BastionContext Context = new BastionContext();

            var images = Context.Images.FindAll();

            Parallel.ForEach(images, new ParallelOptions { MaxDegreeOfParallelism = 10 }, image =>
            {
 
                var server = computeClient.CreateServer("server" + "-" + image.SnapshotId, image.SnapshotId, image.FlavorId).Result;
                image.ServerFromSnapshotId = server.Id;
                Context.Images.Save(image);

                var retries = 0;
                while (server.Status != "ACTIVE")
                {
                    if (retries > 150)
                    {
                        break;
                    }
                    server = computeClient.GetServer(server.Id).Result;
                    Console.WriteLine("Status: " + server.Status);
                    Console.WriteLine("Progress: " + server.Progress);
                    if (server.Status == "ACTIVE")
                    {
                        image.WasBuildFromSnapshotSuccessful = true;
                        Context.Images.Save(image);
                    }
                    Thread.Sleep(15000);
                    retries++;
                }



            });*/

            /*foreach (var i in images)
            {
                var snapshot = computeClient.GetImage(i.SnapshotId).Result;
                if (snapshot.Status == "ACTIVE")
                {
                    i.IsSnapshotActive = true;
                }
                else
                {
                    i.IsSnapshotActive = false;
                }

                Context.Images.Save(i);

            }*/
            
            /*Parallel.ForEach(images, new ParallelOptions { MaxDegreeOfParallelism = 10 }, i =>
            {
                if (i.SnapshotId == null)
                {
                    var imageId = computeClient.CreateImage(i.BaseServerId, "snapshot-" + i.BaseImageId).Result;
                    var snapshot = computeClient.GetImage(imageId).Result;
                    i.SnapshotId = imageId;
                    Context.Images.Save(i);

                    var retries = 0;
                    while (snapshot.Status != "ACTIVE")
                    {
                        if (retries > 100)
                        {
                            break;
                        }
                        snapshot = computeClient.GetImage(imageId).Result;
                        Console.WriteLine("Status: " + snapshot.Status);
                        Console.WriteLine("Progress: " + snapshot.Progress);
                        Thread.Sleep(15000);
                        retries++;

                    }
                }
                
            });*/

            /*var imageId = computeClient.CreateImage("328dd884-eadb-413c-a66a-5e4d85878b90", "stackdotnet").Result;
            var image = computeClient.GetImage(imageId).Result;

            var retries = 0;
            while (image.Status != "ACTIVE")
            {
                if (retries > 100)
                {
                    break;
                }
                image = computeClient.GetImage(imageId).Result;
                Console.WriteLine("Status: " + image.Status);
                Console.WriteLine("Progress: " + image.Progress);
                Thread.Sleep(15000);
                retries++;

            }*/


            /*foreach (var i in images)
            {
                var server = computeClient.GetServer(i.BaseServerId).Result;
                if (server.Status == "ACTIVE")
                {
                    i.IsBaseServerActive = true;
                }
                else
                {
                    i.IsBaseServerActive = false;
                }

                Context.Images.Save(i);

            }*/

            /*var servers = computeClient.ListServers().Result;
            Console.WriteLine(servers.Count());

            var flavors = computeClient.ListFlavorsDetailed().Result;
            var images = computeClient.ListImagesDetailed().Result;

            var standardFlavors = flavors.Where(f => f.Name.Contains("Standard"));
            Console.WriteLine(standardFlavors.Count());


            Parallel.ForEach(images, new ParallelOptions{MaxDegreeOfParallelism=10}, image =>
            {
                standardFlavors.OrderBy(f => f.Ram);
                var flavor = standardFlavors.Where(f => f.Ram >= image.MinRam).First();
                //Console.WriteLine(image.Name + " " + flavor.Id);
                var img = new Image();
                img.BaseImageName = image.Name;
                img.BaseImageId = image.Id;
                img.FlavorId = flavor.Id;

                var server = computeClient.CreateServer("server" + "-" + image.Id, image.Id, flavor.Id).Result;
                img.BaseServerId = server.Id;
                Context.Images.Insert(img);

                var retries = 0;
                while (server.Status != "ACTIVE")
                {
                    if (retries > 100)
                    {
                        break;
                    }
                    server = computeClient.GetServer(server.Id).Result;
                    Console.WriteLine("Status: " + server.Status);
                    Console.WriteLine("Progress: " + server.Progress);
                    Thread.Sleep(15000);
                    retries++;

                }


            });*/

            /*foreach (var image in images)
            {
                standardFlavors.OrderBy(f => f.Ram);
                var flavor = standardFlavors.Where(f => f.Ram >= image.MinRam).First();
                //Console.WriteLine(image.Name + " " + flavor.Id);
                var img = new Image();
                img.BaseImageName = image.Name;
                img.BaseImageId = image.Id;
                img.FlavorId = flavor.Id;

                var server = computeClient.CreateServer("server" + "-" + image.Id, image.Id, flavor.Id).Result;
                img.BaseServerId = server.Id;
                Context.Images.Insert(img);

            }*/

            /*var server = computeClient.CreateServer("csharptest", "ffd597d6-2cc4-4b43-b8f4-b1006715b84e", "performance1-1").Result;

            Console.WriteLine("Created server " + server.Id);
            
            while (server.Status != "ACTIVE")
            {
                server = computeClient.GetServer(server.Id).Result;
                Console.WriteLine("Status: " + server.Status);
                Console.WriteLine("Progress: " + server.Progress);
                Thread.Sleep(15000);
                
            }

            var response = computeClient.DeleteServer(server.Id);
            response.Wait();*/

            /*var servers = computeClient.ListServersDetailed().Result;
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
            Console.WriteLine(accountMeta.BytesUsed);*/

        }
    }
}
