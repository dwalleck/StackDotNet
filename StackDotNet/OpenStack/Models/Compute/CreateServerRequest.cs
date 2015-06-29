using Newtonsoft.Json;
using System.Collections.Generic;

namespace StackDotNet.OpenStack.Models.Compute
{

    public class CreateServerRequest
    {
        [JsonProperty(PropertyName = "server")]
        public CreateServerContent RequestContent { get; set; }

        public CreateServerRequest(string name, string flavorId, string imageId = null, BlockDeviceMapping blockDeviceMapping = null)
        {
            RequestContent = new CreateServerContent
            {
                Name = name,
                FlavorRef = flavorId,
                ImageRef = imageId,
            };

            if (blockDeviceMapping != null)
            {
                RequestContent.BlockDeviceMapping = new List<BlockDeviceMapping> { blockDeviceMapping };
            }
        }
    }

    public class CreateServerContent
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "imageRef")]
        public string ImageRef { get; set; }

        [JsonProperty(PropertyName = "flavorRef")]
        public string FlavorRef { get; set; }

        [JsonProperty(PropertyName = "block_device_mapping")]
        public List<BlockDeviceMapping> BlockDeviceMapping { get; set; }
    }

    public class BlockDeviceMapping
    {
        [JsonProperty(PropertyName = "size")]
        public int Size { get; set; }

        [JsonProperty(PropertyName = "device_name")]
        public string DeviceName { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "delete_on_termination")]
        public bool DeleteOnTermination { get; set; }

        [JsonProperty(PropertyName = "volume_id")]
        public string VolumeId { get; set; }
    }


}
