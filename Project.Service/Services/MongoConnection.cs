using MongoDB.Driver;
using Project.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.Services
{
    public class MongoConnection : IMongoConnection
    {
        public MongoConnection()
        {
        }

        public IMongoDatabase GetMongoDatabase()
        {
            string connectionString = ConfigurationManager.AppSettings["MongoConnectionString"];
            var client = new MongoClient(connectionString);
            return client.GetDatabase("NoteProject");
        }
    }
}
