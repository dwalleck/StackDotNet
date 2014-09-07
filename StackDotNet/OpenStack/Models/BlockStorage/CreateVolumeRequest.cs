using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackDotNet.OpenStack.Models.BlockStorage
{
    public class CreateVolumeRequest
    {
        [JsonProperty(PropertyName = "volume")]
        public CreateVolumeContent RequestContent { get; set; }

        public CreateVolumeRequest(int size, string volumeType, string imageId)
        {
            RequestContent = new CreateVolumeContent
            {
                Size = size,
                VolumeType = volumeType,
                ImageRef = imageId
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
    }
}
