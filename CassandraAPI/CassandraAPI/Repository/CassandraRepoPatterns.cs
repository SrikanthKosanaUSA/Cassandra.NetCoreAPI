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
        private readonly CassandraConfiguration _config;
        public CassandraRepoPatterns(CassandraConfiguration config)
        {
            _config = config;
        }

        public IEnumerable<Student> GetStudents()
        {
            using (var cassandraDA = new CassandraDA(_config))
            {
                var session = cassandraDA.GetSession();
                IMapper mapper = new Mapper(session);

                var students = mapper.Fetch<Student>("Select * From tblStudent;");
                return students;
            }
               
        }

        public Student GetStudentById(int Id)
        {
            using (var cassandraDA = new CassandraDA(_config))
            {
                var session = cassandraDA.GetSession();
                IMapper mapper = new Mapper(session);

                var student = mapper.SingleOrDefault<Student>("Select * From tblStudent Where Id = ?;", Id);
                return student;
            }
        }

        public void NewStudent(Student student)
        {
            using (var cassandraDA = new CassandraDA(_config))
            {
                var session = cassandraDA.GetSession();
                IMapper mapper = new Mapper(session);


                mapper.Execute("Insert into tblstudent(Id, Name, Email, Phone) Values(?,?,?,?)", student.Id, student.Name, student.Email, student.Phone);
                
            }
        }
    }
}
