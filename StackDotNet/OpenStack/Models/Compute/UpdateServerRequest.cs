using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackDotNet.OpenStack.Models.Compute
{
    
    public class UpdateServerRequest
    {
        public UpdateServerContent RequestContent { get; set; }

        public UpdateServerRequest(string name, string accessIPv4, string accessIPv6)
        {
            RequestContent = new UpdateServerContent
            {
                Name = name,
                AccessIPv4 = accessIPv4,
                AccessIPv6 = accessIPv6
            };
        }
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
 