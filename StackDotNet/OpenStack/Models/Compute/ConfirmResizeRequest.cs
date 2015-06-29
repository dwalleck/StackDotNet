using Newtonsoft.Json;

namespace StackDotNet.OpenStack.Models.Compute
{
    public class ConfirmResizeRequest
    {
        [JsonProperty(PropertyName = "confirmResize")]
        public string RequestContent { get; set; }
    }
}
