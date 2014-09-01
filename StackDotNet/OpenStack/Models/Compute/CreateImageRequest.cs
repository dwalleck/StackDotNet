using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackDotNet.OpenStack.Models.Compute
{
    public class CreateImageRequest
    {
        [JsonProperty(PropertyName = "createImage")]
        public CreateImageContent RequestContent { get; set; }

        public CreateImageRequest(string name)
        {
            RequestContent = new CreateImageContent
            {
                Name = name
            };
        }
    }

    public class CreateImageContent
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

    }
}
