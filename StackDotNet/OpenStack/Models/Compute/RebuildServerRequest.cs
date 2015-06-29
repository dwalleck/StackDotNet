using Newtonsoft.Json;

namespace StackDotNet.OpenStack.Models.Compute
{
    public class RebuildServerRequest
    {
        [JsonProperty(PropertyName = "rebuild")]
        public RebuildServerContent RequestContent { get; set; }

        public RebuildServerRequest(string name, string imageId)
        {
            RequestContent = new RebuildServerContent
            {
                Name = name,
                ImageRef = imageId,
            };
        }
    }

    public class RebuildServerContent
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "imageRef")]
        public string ImageRef { get; set; }

    }
}
