using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackDotNet.ThirdParty.Rackspace.Models.CloudIdentity
{
    
    public class AuthRequest
    {
        [JsonProperty(PropertyName = "auth")]
        public Auth Auth { get; set; }

        public AuthRequest(string username, string apiKey, string tenantId)
        {
            Auth = new Auth(username, apiKey, tenantId);
        }
    }

    public class Auth
    {
        [JsonProperty(PropertyName = "RAX-KSKEY:apiKeyCredentials")]
        public ApiKeyCredentials ApiKeyCredentials { get; set; }
        
        [JsonProperty(PropertyName = "tenantId")]
        public string TenantId { get; set; }

        public Auth(string username, string apiKey, string tenantId)
        {
            this.ApiKeyCredentials = new ApiKeyCredentials(username, apiKey);
            this.TenantId = tenantId;
        }   
    }

    public class ApiKeyCredentials
    {
        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }

        [JsonProperty(PropertyName = "apiKey")]
        public string ApiKey { get; set; }

        public ApiKeyCredentials(string username, string apiKey)
        {
            this.Username = username;
            this.ApiKey = apiKey;
        }
    }

    public class Tenant
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }

    public class Token
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "expires")]
        public string Expires { get; set; }

        [JsonProperty(PropertyName = "tenant")]
        public Tenant Tenant { get; set; }
    }

    public class Role
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "tenantName")]
        public string TenantId { get; set; }
    }

    public class User
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "roles")]
        public List<Role> Roles { get; set; }

        [JsonProperty(PropertyName = "roles_links")]
        public List<object> RolesLinks { get; set; }
    }

    public class Endpoint
    {
        [JsonProperty(PropertyName = "tenantId")]
        public string TenantId { get; set; }

        [JsonProperty(PropertyName = "publicURL")]
        public string PublicUrl { get; set; }

        [JsonProperty(PropertyName = "internalURL")]
        public string InternalUrl { get; set; }

        [JsonProperty(PropertyName = "region")]
        public string Region { get; set; }

        [JsonProperty(PropertyName = "versionId")]
        public string versionId { get; set; }

        [JsonProperty(PropertyName = "versionInfo")]
        public string VersionInfo { get; set; }

        [JsonProperty(PropertyName = "versionList")]
        public string VersionList { get; set; }
    }

    public class ServiceCatalog
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "endpoints")]
        public List<Endpoint> Endpoints { get; set; }

        [JsonProperty(PropertyName = "endpoints_links")]
        public List<object> EndpointLinks { get; set; }
    }

    public class Access
    {
        [JsonProperty(PropertyName = "token")]
        public Token Token { get; set; }

        [JsonProperty(PropertyName = "user")]
        public User User { get; set; }

        [JsonProperty(PropertyName = "serviceCatalog")]
        public List<ServiceCatalog> ServiceCatalog { get; set; }

        public Endpoint GetEndpoint(string name, string region)
        {
            //var catalog = ServiceCatalog.Where(c => c.Name == name && c.Endpoints[0].Region == region).FirstOrDefault();
            var service = ServiceCatalog.Where(c => c.Name == name).FirstOrDefault();
            var endpoint = service.Endpoints.Where(s => s.Region == region).FirstOrDefault();
            return endpoint;
        }
    }

    public class RootObject
    {
        [JsonProperty(PropertyName = "access")]
        public Access Access { get; set; }
    }

}
