using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CassandraAPI.Models;
using CassandraAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CassandraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private CassandraConfiguration config;

        public ValuesController(CassandraConfiguration configuration)
        {
            config = configuration;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            CassandraRepoPatterns repo = new CassandraRepoPatterns(config);
            var students = repo.GetStudents();
            return students;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Student> Get(int id)
        {
            CassandraRepoPatterns repo = new CassandraRepoPatterns(config);
            var student = repo.GetStudentById(id);
            return student;
            //return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post(Student student)
        {
            CassandraRepoPatterns repo = new CassandraRepoPatterns(config);
            repo.NewStudent(student);
        }

        // PUT api/values
        [HttpPut]
        public void Put(Student student)
        {
            CassandraRepoPatterns repo = new CassandraRepoPatterns(config);
            repo.ChangeDetails(student);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            CassandraRepoPatterns repo = new CassandraRepoPatterns(config);
            repo.RemoveStudent(id);
        }
    }
}
