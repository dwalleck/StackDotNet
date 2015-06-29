using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace StackDotNet.OpenStack.Models.Compute.Common
{
    public class Metadata : Dictionary<string, string> { }

    public class MetadataTransaction
    {
        [JsonProperty(PropertyName = "metadata")]
        public Metadata Metadata { get; set; }

        public MetadataTransaction() { }

        public MetadataTransaction(Metadata metadata)
        {
            Metadata = metadata;
        }
    }

    public class MetadataItemTransaction
    {
        [JsonProperty(PropertyName = "meta")]
        public Metadata Meta { get; set; }

        public MetadataItemTransaction() { }

        public MetadataItemTransaction(Metadata metadata)
        {
            Meta = metadata;
        }
    }

}
