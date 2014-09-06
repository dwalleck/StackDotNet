using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using StackDotNet.OpenStack.Models.Compute.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.OpenStack.Models.Compute
{
    [TestClass]
    public class MetadataTests
    {
        [TestMethod]
        public void TestMetadataSerialization()
        {
            Metadata metadata = new Metadata()
            {
                {"key1", "value1"},
                {"key12", "value12"},
            };
            var request = new MetadataTransaction(metadata);
            var serializedRequest = JsonConvert.SerializeObject(request);
            var expectedContent = @"{""metadata"":{""key1"":""value1"",""key12"":""value12""}}";
            Assert.AreEqual(serializedRequest, expectedContent);
        }

        [TestMethod]
        public void TestMetadataDeserialization()
        {
            var content = @"{""metadata"":{""key1"":""value1"",""key12"":""value12""}}";
            var metadata = JsonConvert.DeserializeObject<MetadataTransaction>(content);

            Assert.IsTrue(metadata.Metadata.ContainsKey("key1"));
            Assert.AreEqual(metadata.Metadata["key1"], "value1");
            Assert.IsTrue(metadata.Metadata.ContainsKey("key12"));
            Assert.AreEqual(metadata.Metadata["key12"], "value12");
        }

        [TestMethod]
        public void TestMetadataItemSerialization()
        {
            Metadata metadata = new Metadata()
            {
                {"key1", "value1"}
            };
            var request = new MetadataItemTransaction(metadata);
            var serializedRequest = JsonConvert.SerializeObject(request);
            var expectedContent = @"{""meta"":{""key1"":""value1""}}";
            Assert.AreEqual(serializedRequest, expectedContent);
        }

        [TestMethod]
        public void TestMetadataItemDeserialization()
        {
            var content = @"{""meta"":{""key1"":""value1""}}";
            var metadata = JsonConvert.DeserializeObject<MetadataItemTransaction>(content);

            Assert.IsTrue(metadata.Meta.ContainsKey("key1"));
            Assert.AreEqual(metadata.Meta["key1"], "value1");
        }
    }
}
