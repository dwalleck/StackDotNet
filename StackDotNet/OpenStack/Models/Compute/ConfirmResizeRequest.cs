using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackDotNet.OpenStack.Models.Compute
{
    public class ConfirmResizeRequest
    {
        [JsonProperty(PropertyName = "confirmResize")]
        public string RequestContent { get; set; }
    }
}
