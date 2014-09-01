using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackDotNet.OpenStack.Models.Compute
{
    public class ResizeServerRequest
    {
        [JsonProperty(PropertyName = "resize")]
        public ResizeServerContent RequestContent { get; set; }

        public ResizeServerRequest(string flavorRef)
        {
            RequestContent = new ResizeServerContent
            {
                FlavorRef = flavorRef
            };
        }
    }

    public class ResizeServerContent
    {
        [JsonProperty(PropertyName = "flavorRef")]
        public string FlavorRef { get; set; }
    }
}
