using Cassandra.Mapping;
using CassandraAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CassandraAPI
{
    public class CassandraMappings:Mappings
    {
        public CassandraMappings()
        {
            For<Student>()
          .TableName("tblStudent")
          .PartitionKey(u => u.Id);
          
        }
    }
}
