﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StackDotNet.OpenStack.Models.Compute;
using Newtonsoft.Json;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestServerResponse()
        {
            string content = @"{
                                ""server"": {
                                    ""accessIPv4"": ""10.1.1.4"",
                                    ""accessIPv6"": ""3ffe:1900:4545:3:200:f8ff:fe21:67cf"",
                                    ""addresses"": {
                                        ""private"": [
                                            {
                                                ""addr"": ""192.168.0.3"",
                                                ""version"": 4
                                            }
                                        ]
                                    },
                                    ""created"": ""2012-08-20T21:11:09Z"",
                                    ""flavor"": {
                                        ""id"": ""1"",
                                        ""links"": [
                                            {
                                                ""href"": ""https://api.stackdotnet.com/v2/123/flavors/1"",
                                                ""rel"": ""bookmark""
                                            }
                                        ]
                                    },
                                    ""hostId"": ""65201c14a29663e06d0748e561207d998b343e1d164bfa0aafa9c45d"",
                                    ""id"": ""1"",
                                    ""image"": {
                                        ""id"": ""42"",
                                        ""links"": [
                                            {
                                                ""href"": ""https://api.stackdotnet.com/v2/123/images/70a599e0-31e7-49b7-b260-868f441e862b"",
                                                ""rel"": ""bookmark""
                                            }
                                        ]
                                    },
                                    ""links"": [
                                        {
                                            ""href"": ""https://api.stackdotnet.com/v2/123/servers/893c7791-f1df-4c3d-8383-3caae9656c62"",
                                            ""rel"": ""self""
                                        },
                                        {
                                            ""href"": ""https://api.stackdotnet.com/v2/123/servers/893c7791-f1df-4c3d-8383-3caae9656c62"",
                                            ""rel"": ""bookmark""
                                        }
                                    ],
                                    ""metadata"": {
                                        ""key1"": ""value1""
                                    },
                                    ""name"": ""testserver"",
                                    ""progress"": 0,
                                    ""status"": ""ACTIVE"",
                                    ""tenant_id"": ""123"",
                                    ""updated"": ""2012-08-20T21:11:09Z"",
                                    ""user_id"": ""456""
                                }
                            }";

            ServerResponse response = JsonConvert.DeserializeObject<ServerResponse>(content);
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Server);
            
            Assert.AreEqual(response.Server.Id, "1");
            Assert.AreEqual(response.Server.Name,"testserver");
            Assert.AreEqual(response.Server.Progress, 0);
            Assert.AreEqual(response.Server.Status, "ACTIVE");
            Assert.AreEqual(response.Server.TenantId, "123");
            Assert.AreEqual(response.Server.UserId, "456");
            Assert.AreEqual(response.Server.AccessIPv4, "10.1.1.4");
            Assert.AreEqual(response.Server.AccessIPv6, "3ffe:1900:4545:3:200:f8ff:fe21:67cf");

            Assert.IsTrue(response.Server.Metadata.ContainsKey("key1"));
            Assert.AreEqual(response.Server.Metadata["key1"], "value1");

            Assert.AreEqual(response.Server.Image.Id, "42");

            Assert.AreEqual(response.Server.Flavor.Id, "1");
        }

        [TestMethod]
        public void TestCreateServerRequest()
        {
            var request = new CreateServerRequest("testserver", "42", "1");
            var serializedRequest = JsonConvert.SerializeObject(request);
            var expectedContent = @"{""server"":{""name"":""testserver"",""imageRef"":""42"",""flavorRef"":""1""}}";
            Assert.AreEqual(serializedRequest, expectedContent);
        }

        [TestMethod]
        public void TestCreateImageFromServerRequest()
        {
            var request = new CreateImageRequest("testimage");
            var serializedRequest = JsonConvert.SerializeObject(request);
            var expectedContent = @"{""createImage"":{""name"":""testimage""}}";
            Assert.AreEqual(serializedRequest, expectedContent);
        }

        [TestMethod]
        public void TestRebootServerRequest()
        {
            var request = new RebootServerRequest("HARD");
            var serializedRequest = JsonConvert.SerializeObject(request);
            var expectedContent = @"{""reboot"":{""type"":""HARD""}}";
            Assert.AreEqual(serializedRequest, expectedContent);
        }

        [TestMethod]
        public void TestChangePasswordRequest()
        {
            var request = new ChangePasswordRequest("newPassword");
            var serializedRequest = JsonConvert.SerializeObject(request);
            var expectedContent = @"{""changePassword"":{""adminPass"":""newPassword""}}";
            Assert.AreEqual(serializedRequest, expectedContent);
        }

        [TestMethod]
        public void TestUpdateServerRequest()
        {
            var request = new UpdateServerRequest("newName", "192.168.1.5", "3ffe:1900:4545:3:200:f8ff:fe21:67cf");
            var serializedRequest = JsonConvert.SerializeObject(request);
            var expectedContent = @"{""server"":{""name"":""newName"",""accessIPv4"":""192.168.1.5"",""accessIPv6"":""3ffe:1900:4545:3:200:f8ff:fe21:67cf""}}";
            Assert.AreEqual(serializedRequest, expectedContent);
        }

        [TestMethod]
        public void TestConfirmResizeRequest()
        {
            var request = new ConfirmResizeRequest();
            var serializedRequest = JsonConvert.SerializeObject(request);
            var expectedContent = @"{""confirmResize"":null}";
            Assert.AreEqual(serializedRequest, expectedContent);
        }

        [TestMethod]
        public void TestRevertResizeRequest()
        {
            var request = new RevertResizeRequest();
            var serializedRequest = JsonConvert.SerializeObject(request);
            var expectedContent = @"{""revertResize"":null}";
            Assert.AreEqual(serializedRequest, expectedContent);
        }

    }
}