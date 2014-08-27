using StackDotNet.OpenStack.Models.Compute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        Task<Server> CreateServer(string name, string imageId, string flavorId);

        Task<Server> UpdateServer(string name, string accessIPv4, string accessIPv6);

        void GetServerMetadata(string serverId);

        void SetServerMetadata(string serverId);

        void UpdateServerMetadata(string serverId);

        void GetServerMetadataItem(string serverId);

        void SetServerMetadataItem(string serverId);

        Task DeleteServerMetadataItem(string serverId);

        Task ChangeServerPassword(string serverId, string newPassword);

        Task RebootServer(string serverId);

        Task<Server> RebuildServer(string serverId);

        Task ResizeServer(string serverId, string newFlavor);

        Task ConfirmServerResize(string serverId);

        Task RevertServerResize(string serverId);

        Task<string> CreateImage(string serverId, string name);

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

        void GetImageMetadata(string imageId);

        void SetImageMetadata(string imageId);

        void UpdateImageMetadata(string imageId);

        void GetImageMetadataItem(string imageId);

        void SetImageMetadataItem(string imageId);

        Task DeleteImageMetadataItem(string imageId);

        #endregion
    }
}
