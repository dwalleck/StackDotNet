using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace StackDotNet.ThirdParty.Rackspace.Models.CloudLoadBalancers
{
    public class ListLoadBalancersResponse
    {
        [JsonProperty(PropertyName = "loadBalancers")]
        public List<LoadBalancer> LoadBalancers { get; set; }
    }

    public class LoadBalancer
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "protocol")]
        public string Protocol { get; set; }

        [JsonProperty(PropertyName = "port")]
        public int Port { get; set; }

        [JsonProperty(PropertyName = "algorithm")]
        public string Algorithm { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "nodeCount")]
        public int NodeCount { get; set; }

        [JsonProperty(PropertyName = "virtualIps")]
        public Virtualip[] VirtualIPs { get; set; }

        [JsonProperty(PropertyName = "created")]
        public Created Created { get; set; }

        [JsonProperty(PropertyName = "updated")]
        public Updated Updated { get; set; }
    }

    public class Created
    {
        public DateTime time { get; set; }
    }

    public class Updated
    {
        public DateTime time { get; set; }
    }

    public class Virtualip
    {
        public int id { get; set; }
        public string address { get; set; }
        public string type { get; set; }
        public string ipVersion { get; set; }
    }

}
