using System.Collections.Generic;
using Microsoft.AspNet.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AT
{
    [Route("api/people")]
    public class PersonController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return new List<Person>
            {
                new Person {Age = 25, Name = "Bob"},
                new Person {Age = 30, Name = "Alex"},
                new Person {Age = 45, Name = "Allison"},
                new Person {Age = 18, Name = "Jay"}
            };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
