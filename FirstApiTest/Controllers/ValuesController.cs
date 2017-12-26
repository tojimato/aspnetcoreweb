using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FirstApiTest.Controllers
{
    public static class MockObject
    {
        private static List<string> myValues;

        public static List<string> GetInstance()
        {
            if (myValues == null)
            {
                myValues = new List<string>();
            }
            return myValues;
        }
    }
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        public ValuesController()
        {
			Trace.WriteLine("Values controller baslatildi.");
        }
        List<string> myValues = MockObject.GetInstance();
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            Trace.WriteLine("Get value controller action");
            return myValues;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                //Cache Aspects
                //Log
                //Statistics
                //Complation Time
                //Auth Aspects
                //Validations
                if (id > myValues.Count() - 1)
                {
                    return NotFound("MyValues dizisi icinde veri bulunamadi.");
                }
                Trace.WriteLine("Get value controller action");
                return Ok(myValues[id]);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
            myValues.Add(value);
            Trace.WriteLine("Post value controller action");
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            myValues[id] = value;
            Trace.WriteLine("PUT value controller action");
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            myValues.RemoveAt(id);
            Trace.WriteLine("DELETE value controller action");
        }
    }
}
