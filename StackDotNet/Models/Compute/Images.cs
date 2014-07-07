using Newtonsoft.Json;
using StackDotNet.Models.Compute.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackDotNet.Models.Compute
{
    public class Image
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "links")]
        public List<Link> links { get; set; }
    }
}
