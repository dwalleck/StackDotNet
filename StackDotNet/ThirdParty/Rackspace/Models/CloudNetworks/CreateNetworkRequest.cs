using Newtonsoft.Json;

namespace StackDotNet.ThirdParty.Rackspace.Models.CloudNetworks
{
    public class CreateNetworkRequest
    {
        [JsonProperty(PropertyName = "network")]
        public CreateNetworkContent RequestContent { get; set; }

        public CreateNetworkRequest(string cidr, string label)
        {
            RequestContent = new CreateNetworkContent
            {
                Cidr = cidr,
                Label = label,
            };
        }
    }

    public class CreateNetworkContent
    {
        [JsonProperty(PropertyName = "cidr")]
        public string Cidr { get; set; }

        [JsonProperty(PropertyName = "label")]
        public string Label { get; set; }

    }
}
