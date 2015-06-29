using Newtonsoft.Json;

namespace StackDotNet.OpenStack.Models.Compute
{
    public class RevertResizeRequest
    {
        [JsonProperty(PropertyName = "revertResize")]
        public string RequestContent { get; set; }
    }
}
