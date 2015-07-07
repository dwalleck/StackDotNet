using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace StackDotNet.OpenStack.Models.Identity
{
    public class AuthRequest
    {
        [JsonProperty(PropertyName = "auth")]
        public Auth Auth { get; set; }

        public AuthRequest(string username, string password, string tenantName)
        {
            Auth = new Auth(username, password, tenantName);
        }
    }

    public class Auth
    {
        [JsonProperty(PropertyName = "passwordCredentials")]
        public PasswordCredentials PasswordCredentials { get; set; }

        [JsonProperty(PropertyName = "tenantName")]
        public string TenantName { get; set; }

        public Auth(string username, string password, string tenantName)
        {
            this.PasswordCredentials = new PasswordCredentials(username, password);
            this.TenantName = tenantName;
        }
    }

    public class PasswordCredentials
    {
        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }

        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }

        public PasswordCredentials(string username, string password)
        {
            this.Username = username;
            this.Password = password;
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
            var catalog = ServiceCatalog.Where(c => c.Name == name && c.Endpoints[0].Region == region).FirstOrDefault();

            var endpoint = ServiceCatalog
                .Where(c => c.Name == name).FirstOrDefault()?.Endpoints
                .Where(e => e.Region == region)?.FirstOrDefault();
            /*if (catalog == null)
            {
                return null;
            }
            return catalog.Endpoints[0];*/
            return endpoint;
        }
    }

    public class RootObject
    {
        [JsonProperty(PropertyName = "access")]
        public Access Access { get; set; }
    }
}
