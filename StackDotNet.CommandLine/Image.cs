using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackDotNet.CommandLine
{
    public class Image
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string BaseImageId { get; set; }
        public string BaseImageName { get; set; }
        public string FlavorId { get; set; }
        public string BaseServerId { get; set; }
        public string SnapshotId { get; set; }
        public bool IsBaseServerActive { get; set; }
        public bool IsSnapshotActive { get; set; }
        public string ServerFromSnapshotId { get; set; }
        public bool WasBuildFromSnapshotSuccessful { get; set; }
        public bool WasMigrationSuccessful { get; set; }

    }
}
