using Newtonsoft.Json;
using System.Collections.Generic;

namespace StackDotNet.ThirdParty.Rackspace.Models.CloudNetworks
{
    public class Network
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "cidr")]
        public string Cidr { get; set; }

        [JsonProperty(PropertyName = "label")]
        public string Label { get; set; }
    }

    public class ListNetworksResponse
    {
        [JsonProperty(PropertyName = "networks")]
        public List<Network> Networks { get; set; }
    }

    public class NetworkResponse
    {
        [JsonProperty(PropertyName = "network")]
        public Network Network { get; set; }
    }
}
