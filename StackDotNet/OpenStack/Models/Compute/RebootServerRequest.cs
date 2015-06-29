using Newtonsoft.Json;

namespace StackDotNet.OpenStack.Models.Compute
{
    public class RebootServerRequest
    {
        [JsonProperty(PropertyName = "reboot")]
        public RebootServerContent RequestContent { get; set; }

        public RebootServerRequest(string type)
        {
            RequestContent = new RebootServerContent
            {
                Type = type
            };
        }
    }

    public class RebootServerContent
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
    }
}
