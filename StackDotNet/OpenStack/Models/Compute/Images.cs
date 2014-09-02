using Newtonsoft.Json;
using StackDotNet.OpenStack.Models.Compute.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackDotNet.OpenStack.Models.Compute
{
    public class Image
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "links")]
        public List<Link> links { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "updated")]
        public DateTime Updated { get; set; }

        [JsonProperty(PropertyName = "OS-DCF:diskConfig")]
        public string DiskConfig { get; set; }

        [JsonProperty(PropertyName = "OS-EXT-IMG-SIZE:size")]
        public long Size { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "created")]
        public DateTime Created { get; set; }

        [JsonProperty(PropertyName = "minDisk")]
        public int MinDisk { get; set; }

        [JsonProperty(PropertyName = "progress")]
        public int Progress { get; set; }

        [JsonProperty(PropertyName = "minRam")]
        public int MinRam { get; set; }

        [JsonProperty(PropertyName = "metadata")]
        public Metadata Metadata { get; set; }
    }

    public class ListImagesResponse
    {
        [JsonProperty(PropertyName = "images")]
        public List<Image> Images { get; set; }
    }

    public class GetImageResponse
    {
        [JsonProperty(PropertyName = "image")]
        public Image Image { get; set; }
    }

}
