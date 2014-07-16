using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackDotNet.Models.Compute.Common;
using Newtonsoft.Json;

namespace StackDotNet.Models.Compute
{
    public class Flavor
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "links")]
        public List<Link> Links { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "disk")]
        public int Disk { get; set; }

        [JsonProperty(PropertyName = "ram")]
        public int Ram { get; set; }

        [JsonProperty(PropertyName = "vcpus")]
        public int VCPUs { get; set; }
    }

    public class ListFlavorsResponse
    {
        [JsonProperty(PropertyName = "flavors")]
        public List<Flavor> Flavors { get; set; }
    }

    public class GetFlavorResponse
    {
        [JsonProperty(PropertyName = "flavor")]
        public Flavor Flavor { get; set; }
    }
}
