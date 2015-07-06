using System.Collections.Generic;
using StackDotNet.OpenStack.Models.Compute.Common;
using Newtonsoft.Json;

namespace StackDotNet.OpenStack.Models.Compute
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

        [JsonProperty(PropertyName = "OS-FLV-WITH-EXT-SPECS:extra_specs")]
        public FlavorExtraSpecs ExtraSpecs { get; set; }

        [JsonProperty(PropertyName = "OS-FLV-EXT-DATA:ephemeral")]
        public int EphemeralDisk { get; set; }
    }

    public class FlavorExtraSpecs
    {
        [JsonProperty(PropertyName = "policy_class")]
        public string PolicyClass { get; set; }

        [JsonProperty(PropertyName = "class")]
        public string Class { get; set; }

        [JsonProperty(PropertyName = "disk_io_index")]
        public int DiskIOIndex { get; set; }

        [JsonProperty(PropertyName = "number_of_data_disks")]
        public int NumberOfDataDisks { get; set; }

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
