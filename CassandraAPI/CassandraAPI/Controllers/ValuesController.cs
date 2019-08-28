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
        public Student Get()
        {
            CassandraRepoPatterns repo = new CassandraRepoPatterns();
            var student = repo.GetStudents(config);
            return student;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
