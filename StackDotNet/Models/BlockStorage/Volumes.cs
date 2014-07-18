using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackDotNet.Models.BlockStorage
{
    public class Volume
    {
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "display_name")]
        public string DisplayName { get; set; }

        [JsonProperty(PropertyName = "attachments")]
        public List<Attachment> Attachments { get; set; }

        [JsonProperty(PropertyName = "availability_zone")]
        public string AvailabilityZone { get; set; }

        [JsonProperty(PropertyName = "bootable")]
        public bool Bootable { get; set; }

        [JsonProperty(PropertyName = "created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty(PropertyName = "os-vol-tenant-attr:tenant_id")]
        public string TenantId { get; set; }

        [JsonProperty(PropertyName = "display_description")]
        public string DisplayDescription { get; set; }

        [JsonProperty(PropertyName = "os-vol-host-attr:host")]
        public string Host { get; set; }

        [JsonProperty(PropertyName = "volume_type")]
        public string VolumeType { get; set; }

        [JsonProperty(PropertyName = "snapshot_id")]
        public string SnapshotId { get; set; }

        [JsonProperty(PropertyName = "source_volid")]
        public string SourceVolumeId { get; set; }

        [JsonProperty(PropertyName = "os-vol-mig-status-attr:name_id")]
        public string MigrationStatusNameId { get; set; }

        [JsonProperty(PropertyName = "metadata")]
        public Metadata Metadata { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "os-vol-mig-status-attr:migstat")]
        public string MigrationStatus { get; set; }

        [JsonProperty(PropertyName = "size")]
        public int Size { get; set; }
    }

    
    public class ListVolumesResponse
    {
        [JsonProperty(PropertyName = "volumes")]
        public List<Volume> Volumes { get; set; }
    }


    public class Metadata
    {
    
    }

    public class Attachment
    {
        [JsonProperty(PropertyName = "host_name")]
        public string HostName { get; set; }

        [JsonProperty(PropertyName = "device")]
        public string Device { get; set; }

        [JsonProperty(PropertyName = "server_id")]
        public string ServerId { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "volume_id")]
        public string VolumeId { get; set; }
    }

}
