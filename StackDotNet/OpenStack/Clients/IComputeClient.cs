using StackDotNet.OpenStack.Models.Compute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackDotNet.OpenStack.Clients
{
    interface IComputeClient
    {
        #region Servers

        public async Task<List<Server>> ListServers();

        public async Task<List<Server>> ListServersDetailed();

        public async Task<Server> GetServer(string serverId);

        public async Task DeleteServer(string serverId);

        public async Task<Addresses> ListServerAddresses(string serverId);

        public async Task<Server> CreateServer(string name, string imageId, string flavorId);

        public async Task<Server> UpdateServer(string name, string accessIPv4, string accessIPv6);

        public async void GetServerMetadata(string serverId);

        public async void SetServerMetadata(string serverId);

        public async void UpdateServerMetadata(string serverId);

        public async void GetServerMetadataItem(string serverId);

        public async void SetServerMetadataItem(string serverId);

        public async Task DeleteServerMetadataItem(string serverId);

        public async Task ChangeServerPassword(string serverId, string newPassword);

        public async Task RebootServer(string serverId);

        public async Task<Server> RebuildServer(string serverId);

        public async Task ResizeServer(string serverId, string newFlavor);

        public async Task ConfirmServerResize(string serverId);

        public async Task RevertServerResize(string serverId);

        public async Task CreateImage(string serverId);

        #endregion

        #region Flavors
        public async Task<List<Flavor>> ListFlavors();

        public async Task<List<Flavor>> ListFlavorsDetailed();

        public async Task<Flavor> GetFlavor(string flavorId);

        #endregion

        #region Images

        public async Task<List<Image>> ListImages();

        public async Task<List<Image>> ListImagesDetailed();

        public async Task DeleteImage(string imageId);

        public async void GetImageMetadata(string imageId);

        public async void SetImageMetadata(string imageId);

        public async void UpdateImageMetadata(string imageId);

        public async void GetImageMetadataItem(string imageId);

        public async void SetImageMetadataItem(string imageId);

        public async Task DeleteImageMetadataItem(string imageId);

        #endregion
    }
}
