using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackDotNet.OpenStack.Models.Compute.Common
{
    public class Link
    {
        [JsonProperty(PropertyName = "Href")]
        public string href { get; set; }

        [JsonProperty(PropertyName = "Rel")]
        public string rel { get; set; }
    }
}
