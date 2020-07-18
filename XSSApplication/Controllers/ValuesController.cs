using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using XSSApplication.Models;

namespace XSSApplication.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/<controller>
        [Route("api/Values/Get/{id}")]
        [HttpGet]
        public string Get(int id)
        {
            Debug.WriteLine("\n" + "TestGet" + "\n");
            Debug.WriteLine("\n" + DatabaseModel.getDatabase().get(id) + "\n");
            return DatabaseModel.getDatabase().get(id); 
        }

        // POST api/<controller>
        [Route("api/Values/Add/")]
        [HttpPost]
        public void Post([FromBody]Data data)
        {
            Debug.WriteLine("\n" + "TestAdd" + data.d + "\n");
            DatabaseModel.getDatabase().add(data.d);
        }
    }
}