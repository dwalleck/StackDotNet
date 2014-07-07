using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackDotNet.Models.Identity
{
    public class AuthRequest
    {
        public Auth auth { get; set; }
        public AuthRequest(string username, string password, string tenantName)
        {
            auth = new Auth(username, password, tenantName);
        }
    }

    public class Auth
    {
        public PasswordCredentials passwordCredentials { get; set; }
        public string tenantName { get; set; }

        public Auth(string username, string password, string tenantName)
        {
            this.passwordCredentials = new PasswordCredentials(username, password);
            this.tenantName = tenantName;
        }
    }

    public class PasswordCredentials
    {
        public string username { get; set; }
        public string password { get; set; }
        public PasswordCredentials(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }

    public class Tenant
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Token
    {
        public string id { get; set; }
        public string expires { get; set; }
        public Tenant tenant { get; set; }
    }

    public class Role
    {
        public string id { get; set; }
        public string name { get; set; }
        public string tenantId { get; set; }
    }

    public class User
    {
        public string id { get; set; }
        public string name { get; set; }
        public List<Role> roles { get; set; }

        [JsonProperty(PropertyName = "roles_links")]
        public List<object> RolesLinks { get; set; }
    }

    public class Endpoint
    {
        public string tenantId { get; set; }
        public string publicURL { get; set; }
        public string internalURL { get; set; }
        public string region { get; set; }
        public string versionId { get; set; }
        public string versionInfo { get; set; }
        public string versionList { get; set; }
    }

    public class ServiceCatalog
    {
        public string name { get; set; }
        public string type { get; set; }
        public List<Endpoint> endpoints { get; set; }
        public List<object> endpoints_links { get; set; }

        
    }

    public class Access
    {
        public Token token { get; set; }
        public User user { get; set; }
        public List<ServiceCatalog> serviceCatalog { get; set; }

        public Endpoint GetEndpoint(string name, string region)
        {
            var catalog = serviceCatalog.Where(c => c.name == name && c.endpoints[0].region == region).FirstOrDefault();
            return catalog.endpoints[0];
        }
    }

    public class RootObject
    {
        public Access access { get; set; }
    }
}
