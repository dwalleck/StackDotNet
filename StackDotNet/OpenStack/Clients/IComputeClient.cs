using StackDotNet.OpenStack.Models.Compute;
using StackDotNet.OpenStack.Models.Compute.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackDotNet.OpenStack.Clients
{
    public interface IComputeClient
    {
        #region Servers

        Task<List<Server>> ListServers();

        Task<List<Server>> ListServersDetailed();

        Task<Server> GetServer(string serverId);

        Task DeleteServer(string serverId);

        Task<Addresses> ListServerAddresses(string serverId);

        Task<Server> CreateServer(string name, string flavorId, string imageId = null, BlockDeviceMapping blockDevice = null);

        Task<Server> UpdateServer(string serverId, string name, string accessIPv4, string accessIPv6);

        Task<Metadata> GetServerMetadata(string serverId);

        Task<Metadata> SetServerMetadata(string serverId, Metadata metadata);

        Task<Metadata> UpdateServerMetadata(string serverId, Metadata metadata);

        Task<Metadata> GetServerMetadataItem(string serverId, string key);

        Task<Metadata> SetServerMetadataItem(string serverId, string key, string value);

        Task DeleteServerMetadataItem(string serverId, string key);

        Task ChangeServerPassword(string serverId, string newPassword);

        Task RebootServer(string serverId, string type);

        Task<Server> RebuildServer(string serverId, string name, string imageId);

        Task ResizeServer(string serverId, string newFlavor);

        Task ConfirmServerResize(string serverId);

        Task RevertServerResize(string serverId);

        Task<string> CreateImage(string serverId, string name);

        Task<List<InstanceAction>> ListInstanceActions(string serverId);

        #endregion

        #region Flavors

        Task<List<Flavor>> ListFlavors();

        Task<List<Flavor>> ListFlavorsDetailed();

        Task<Flavor> GetFlavor(string flavorId);

        #endregion

        #region Images

        Task<List<Image>> ListImages();

        Task<List<Image>> ListImagesDetailed();

        Task DeleteImage(string imageId);

        Task<Image> GetImage(string imageId);

        Task<Metadata> GetImageMetadata(string imageId);

        Task<Metadata> SetImageMetadata(string imageId, Metadata metadata);

        Task<Metadata> UpdateImageMetadata(string imageId, Metadata metadata);

        Task<Metadata> GetImageMetadataItem(string imageId, string key);

        Task<Metadata> SetImageMetadataItem(string imageId, string key, string value);

        Task DeleteImageMetadataItem(string imageId, string key);

        #endregion
    }
}
