using Cassandra;

namespace CassandraAPI.Repository
{
    public interface ICassandraDataAccess
    {
        ISession GetSession();
    }
}