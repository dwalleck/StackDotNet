using Newtonsoft.Json;

namespace StackDotNet.OpenStack.Models.Compute
{
    public class ResizeServerRequest
    {
        [JsonProperty(PropertyName = "resize")]
        public ResizeServerContent RequestContent { get; set; }

        public ResizeServerRequest(string flavorRef)
        {
            RequestContent = new ResizeServerContent
            {
                FlavorRef = flavorRef
            };
        }
    }

    public class ResizeServerContent
    {
        [JsonProperty(PropertyName = "flavorRef")]
        public string FlavorRef { get; set; }
    }
}
