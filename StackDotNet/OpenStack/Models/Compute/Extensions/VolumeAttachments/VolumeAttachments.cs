using Newtonsoft.Json;
using System.Collections.Generic;

namespace StackDotNet.OpenStack.Models.Compute.Extensions.VolumeAttachments
{

    public class ListVolumeAttachmentsResponse
    {
        [JsonProperty(PropertyName = "volumeAttachments")]
        public List<VolumeAttachment> VolumeAttachments { get; set; }
    }

    public class VolumeAttachment
    {
        [JsonProperty(PropertyName = "device")]
        public string Device { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "serverId")]
        public string ServerId { get; set; }

        [JsonProperty(PropertyName = "volumeId")]
        public string VolumeId { get; set; }
    }

}
