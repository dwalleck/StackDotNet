using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackDotNet.Models.Compute.Common;

namespace StackDotNet.Models.Compute
{
    public class Flavor
    {
        public string id { get; set; }
        public Link[] links { get; set; }
        public string name { get; set; }
    }
}
