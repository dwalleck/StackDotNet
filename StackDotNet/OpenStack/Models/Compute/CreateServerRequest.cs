using Newtonsoft.Json;
using System.Collections.Generic;

namespace StackDotNet.OpenStack.Models.Compute
{

    public class CreateServerRequest
    {
        [JsonProperty(PropertyName = "server")]
        public CreateServerContent RequestContent { get; set; }

        public CreateServerRequest(string name, string flavorId, string imageId = null, BlockDeviceMapping blockDeviceMapping = null,
            string diskConfig = null, string adminPassword = null, string keyName = null, bool? isConfigDriveEnabled = null,
            string accessIPv4Address = null, string accessIPv6Address = null)
        {
            RequestContent = new CreateServerContent
            {
                Name = name,
                FlavorRef = flavorId,
                ImageRef = imageId,
                DiskConfig = diskConfig,
                AdminPassword = adminPassword,
                KeyName = keyName,
                IsConfigDriveEnabled = isConfigDriveEnabled,
                AccessIPv4Address = accessIPv4Address,
                AccessIPv6Address = accessIPv6Address
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

        [JsonProperty(PropertyName = "disk_config")]
        public string DiskConfig { get; set; }

        [JsonProperty(PropertyName = "admin_pass")]
        public string AdminPassword { get; set; }

        [JsonProperty(PropertyName = "key_name")]
        public string KeyName { get; set; }

        [JsonProperty(PropertyName = "config_drive")]
        public bool? IsConfigDriveEnabled { get; set; }

        [JsonProperty(PropertyName = "accessIPv4")]
        public string AccessIPv4Address { get; set; }

        [JsonProperty(PropertyName = "accessIPv6")]
        public string AccessIPv6Address { get; set; }

    }

    public class BlockDeviceMapping
    {
        [JsonProperty(PropertyName = "boot_index")]
        public int BootIndex { get; set; }

        [JsonProperty(PropertyName = "uuid")]
        public string Uuid { get; set; }

        [JsonProperty(PropertyName = "volume_size")]
        public int VolumeSize { get; set; }

        [JsonProperty(PropertyName = "source_type")]
        public string SourceType { get; set; }

        [JsonProperty(PropertyName = "destination_type")]
        public string DestinationType { get; set; }

        [JsonProperty(PropertyName = "delete_on_termination")]
        public bool DeleteOnTermination { get; set; }
    }


}
