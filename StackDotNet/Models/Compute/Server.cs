using Newtonsoft.Json;
using StackDotNet.Models.Compute.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackDotNet.Models.Compute
{
    public class Server
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "tenant_id")]
        public string TenantId { get; set; }

        [JsonProperty(PropertyName = "user_id")]
        public string UserId { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; set; }

        [JsonProperty(PropertyName = "created")]
        public string Created { get; set; }

        [JsonProperty(PropertyName = "hostId")]
        public string HostId { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "progress")]
        public int Progress { get; set; }

        [JsonProperty(PropertyName = "accessIPv4")]
        public string AccessIPv4 { get; set; }

        [JsonProperty(PropertyName = "accessIPv6")]
        public string AccessIPv6 { get; set; }

        [JsonProperty(PropertyName = "image")]
        public Image Image { get; set; }

        [JsonProperty(PropertyName = "flavor")]
        public Flavor Flavor { get; set; }

        [JsonProperty(PropertyName = "addresses")]
        public Addresses Addresses { get; set; }

        [JsonProperty(PropertyName = "metadata")]
        public Metadata Metadata { get; set; }

        [JsonProperty(PropertyName = "links")]
        public List<Link> Links { get; set; }

        [JsonProperty(PropertyName = "key_name")]
        public string KeyName { get; set; }

        [JsonProperty(PropertyName = "OS-EXT-STS:task_state")]
        public string TaskState { get; set; }

        [JsonProperty(PropertyName = "OS-EXT-STS:vm_state")]
        public string VmState { get; set; }

        [JsonProperty(PropertyName = "OS-EXT-AZ:availability_zone")]
        public string AvailabilityZone { get; set; }

        [JsonProperty(PropertyName = "OS-EXT-STS:power_state")]
        public int PowerState { get; set; }

        [JsonProperty(PropertyName = "OS-DCF:diskConfig")]
        public string DiskConfig { get; set; }

        [JsonProperty(PropertyName = "config_drive")]
        public string ConfigDrive { get; set; }

        [JsonProperty(PropertyName = "OS-SRV-USG:terminated_at")]
        public string TerminatedAt { get; set; }

        [JsonProperty(PropertyName = "OS-SRV-USG:launched_at")]
        public string LaunchedAt { get; set; }

    }

    public class Addresss
    {
        [JsonProperty(PropertyName = "version")]
        public int Version { get; set; }

        [JsonProperty(PropertyName = "addr")]
        public string Address { get; set; }

        [JsonProperty(PropertyName = "OS-EXT-IPS-MAC:mac_addr")]
        public string MacAddress { get; set; }

        [JsonProperty(PropertyName = "OS-EXT-IPS:type")]
        public string AddressType { get; set; }
    }

    public class Addresses
    {
        [JsonProperty(PropertyName = "public")]
        public List<Addresss> PublicAddresses { get; set; }

        [JsonProperty(PropertyName = "private")]
        public List<Addresss> PrivateAddresses { get; set; }
    }

    public class Metadata
    {

    }

    public class ListServersResponse
    {
        [JsonProperty(PropertyName = "servers")]
        public List<Server> Servers { get; set; }
    }

    public class GetServerResponse
    {
        [JsonProperty(PropertyName = "server")]
        public Server Server { get; set; }
    }
}
