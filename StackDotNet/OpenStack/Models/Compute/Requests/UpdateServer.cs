using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackDotNet.OpenStack.Models.Compute.Requests
{
    
    public class UpdateServerRequest
    {
        public UpdateServerContent server { get; set; }
    }

    public class UpdateServerContent
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "accessIPv4")]
        public string AccessIPv4 { get; set; }

        [JsonProperty(PropertyName = "accessIPv6")]
        public string AccessIPv6 { get; set; }
    }

}
 