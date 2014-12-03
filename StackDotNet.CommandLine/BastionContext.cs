using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackDotNet.CommandLine.Properties;

namespace StackDotNet.CommandLine
{
    public class BastionContext
    {
        public MongoDatabase Database;

        public BastionContext()
        {
            var client = new MongoClient(Settings.Default.BastionConnectionString);
            MongoServer server = client.GetServer();
            Database = server.GetDatabase(Settings.Default.BastionDatabaseName);
        }

        public MongoCollection<Image> Images
        {
            get
            {
                return Database.GetCollection<Image>("images");
            }
        }

        public MongoCollection<ActionResults> Results
        {
            get
            {
                return Database.GetCollection<ActionResults>("results");
            }
        }
    }

}
