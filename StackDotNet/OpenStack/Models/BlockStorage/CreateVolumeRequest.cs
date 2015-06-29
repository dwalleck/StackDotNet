using Newtonsoft.Json;

namespace StackDotNet.OpenStack.Models.BlockStorage
{
    public class CreateVolumeRequest
    {
        [JsonProperty(PropertyName = "volume")]
        public CreateVolumeContent RequestContent { get; set; }

        public CreateVolumeRequest(int size, string volumeType, string imageId, string name)
        {
            RequestContent = new CreateVolumeContent
            {
                Size = size,
                VolumeType = volumeType,
                ImageRef = imageId,
                Name = name
            };
        }
    }

    public class CreateVolumeContent
    {
        [JsonProperty(PropertyName = "size")]
        public int Size { get; set; }

        [JsonProperty(PropertyName = "volume_type")]
        public string VolumeType { get; set; }

        [JsonProperty(PropertyName = "imageRef")]
        public string ImageRef { get; set; }

        [JsonProperty(PropertyName = "display_name")]
        public string Name { get; set; }
    }
}
