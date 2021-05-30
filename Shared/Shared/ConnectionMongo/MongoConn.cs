using MongoDB.Driver;

namespace Shared.ConnectionMongo
{
    public class MongoConn
    {
        public string NameDataBase { get; set; }
        public string StringConnection { get; set; }
        public string NameCollection { get; set; }
        private IMongoDatabase Database { get; set; }
        private IMongoClient Client { get; set; }

        private IMongoDatabase GetConnection()
        {
            if (Database != null)
                return Database;

            //string serverPort = ConnectionStringMongoDB.Substring(ConnectionStringMongoDB.IndexOf("@") + 1, ConnectionStringMongoDB.Substring(ConnectionStringMongoDB.IndexOf("@")).IndexOf("/") - 1);
            //string user = ConnectionStringMongoDB.Substring(ConnectionStringMongoDB.IndexOf("//") + 2, ConnectionStringMongoDB.Substring(ConnectionStringMongoDB.IndexOf("//") + 2).IndexOf("@"));

            //List<MongoServerAddress> servers = new List<MongoServerAddress>();

            //foreach (var itemServer in serverPort.Split(','))
            //{
            //    servers.Add(new MongoServerAddress(itemServer.Split(':')[0], Convert.ToInt32(itemServer.Split(':')[1])));
            //}

            //var credentials = MongoCredential.CreateCredential("admin", user.Split(':')[0], user.Split(':')[1]);

            //var clientSettings = new MongoClientSettings
            //{
            //    Credential = credentials,
            //    ConnectTimeout = TimeSpan.FromSeconds(180),
            //    Servers = servers,
            //    MaxConnectionPoolSize = 5000,
            //    WaitQueueTimeout = TimeSpan.FromMinutes(5),
            //    ServerSelectionTimeout = TimeSpan.FromMinutes(3),
            //    SocketTimeout = TimeSpan.FromMinutes(2),
            //    WaitQueueSize = 5000,
            //    ReplicaSetName = "",
            //    RetryWrites = true,
            //};
            //Client = new MongoClient(clientSettings);
            //Database = Client.GetDatabase("");

            IMongoClient client = new MongoClient(StringConnection);
            if (Database == null)
                Database = client.GetDatabase(NameDataBase);

            return Database;
        }
        public IMongoCollection<T> Collection<T>()
        {
            return GetConnection().GetCollection<T>(NameCollection);
        }
    }
}
