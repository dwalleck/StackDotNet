using Newtonsoft.Json;

namespace StackDotNet.OpenStack.Models.Compute
{
    public class ChangePasswordRequest
    {
        [JsonProperty(PropertyName = "changePassword")]
        public ChangePasswordContent RequestContent { get; set; }

        public ChangePasswordRequest(string password)
        {
            RequestContent = new ChangePasswordContent
            {
                Password = password
            };
        }
    }

    public class ChangePasswordContent
    {
        [JsonProperty(PropertyName = "adminPass")]
        public string Password { get; set; }
    }

}
