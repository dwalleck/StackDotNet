﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackDotNet.OpenStack.Models.Compute
{
    
    public class CreateServerRequest
    {
        [JsonProperty(PropertyName = "server")]
        public CreateServerContent RequestContent { get; set; }

        public CreateServerRequest(string name, string imageId, string flavorId)
        {
            RequestContent = new CreateServerContent
            {
                Name = name,
                ImageRef = imageId,
                FlavorRef = flavorId
            };
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
    }


}