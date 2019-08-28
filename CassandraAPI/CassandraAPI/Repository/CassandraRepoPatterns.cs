using Cassandra.Mapping;
using CassandraAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CassandraAPI.Repository
{
    public class CassandraRepoPatterns
    {

        public Student GetStudents(CassandraConfiguration config)
        {
            using (var cassandraDA = new CassandraDA(config))
            {
                var session = cassandraDA.GetSession();
                IMapper mapper = new Mapper(session);

                var student = mapper.Single<Student>("Select * From tblStudent where id = 3;");
                return student;
            }
               
        }
    }
}
