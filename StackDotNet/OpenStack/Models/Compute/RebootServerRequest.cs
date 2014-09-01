using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackDotNet.OpenStack.Models.Compute
{
    public class RebootServerRequest
    {
        [JsonProperty(PropertyName = "reboot")]
        public RebootServerContent RequestContent { get; set; }

        public RebootServerRequest(string type)
        {
            RequestContent = new RebootServerContent
            {
                Type = type
            };
        }
    }

    public class RebootServerContent
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
    }
}
