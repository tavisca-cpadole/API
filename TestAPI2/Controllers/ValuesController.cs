using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace TestAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(string id)
        {
            if (id == "hello")
                return "hi";
            else if (id == "hi")
                return "hello";
            else return "invalid";
        }

        // POST api/values
        [HttpPost]
        public string Post([FromBody] JObject jsonObj)
        {
            Dictionary<string, string> dictObj = jsonObj.ToObject<Dictionary<string, string>>();
            int data = 1;
            foreach (var item in dictObj)
            {
                data = data * Int32.Parse(item.Value);
            }
            return data.ToString() ;
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
