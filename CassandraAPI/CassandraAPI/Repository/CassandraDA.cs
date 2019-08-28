using Cassandra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CassandraAPI.Repository
{
    public class CassandraDA : ICassandraDataAccess, IDisposable
    {
        public CassandraConfiguration _config;
        public readonly string keyspace;
        public Cluster cluster;
        public ISession session;

        public CassandraDA(CassandraConfiguration config)
        {
            _config = config;
            keyspace = config.keySpace;
        }

        public Cluster Connect()
        {
            var cluster = Cluster.Builder().AddContactPoint(_config.database).Build();

            return cluster;
        }
        public ISession GetSession()
        {
            cluster = Connect();
            session = cluster.Connect(keyspace);
            return session;
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
