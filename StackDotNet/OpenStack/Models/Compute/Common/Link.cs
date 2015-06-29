using Newtonsoft.Json;

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
