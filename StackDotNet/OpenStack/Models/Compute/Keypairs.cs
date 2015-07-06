using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StackDotNet.OpenStack.Models.Compute
{
    public class ListKeypairsResponse
    {
        [JsonProperty(PropertyName = "keypairs")]
        public List<Keypair> Keypairs { get; set; }
    }

    public class GetKeypairResponse
    {
        [JsonProperty(PropertyName = "keypair")]
        public Keypair Keypair { get; set; }
    }

    public class Keypair
    {
        [JsonProperty(PropertyName = "fingerprint")]
        public string Fingerprint { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "public_key")]
        public string PublicKey { get; set; }
    }

}
