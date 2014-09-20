using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StackDotNet.ThirdParty.Rackspace.Models.CloudNetworks;
using Newtonsoft.Json;

namespace Tests.ThirdParty.Rackspace.Models
{
    [TestClass]
    public class CloudNetworksTests
    {
        [TestMethod]
        public void TestCreateNetworkRequest()
        {
            var request = new CreateNetworkRequest("192.168.2.0/24", "testnet");
            var serializedRequest = JsonConvert.SerializeObject(request);
            var expectedContent = @"{""network"":{""cidr"":""192.168.2.0/24"",""label"":""testnet""}}";
            Assert.AreEqual(serializedRequest, expectedContent);
        }

        [TestMethod]
        public void TestNetworkResponse()
        {
            string content = @"{
                                ""network"": {
                                    ""cidr"": ""192.168.0.0/24"",
                                    ""id"": ""5"",
                                    ""label"": ""testnet""
                                    }
                                }";

            NetworkResponse response = JsonConvert.DeserializeObject<NetworkResponse>(content);
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Network);

            Assert.AreEqual(response.Network.Id, "5");
            Assert.AreEqual(response.Network.Cidr, "192.168.0.0/24");
            Assert.AreEqual(response.Network.Label, "testnet");
        }

    }
}
