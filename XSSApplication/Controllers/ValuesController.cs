using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CCSEPAssignment.Models;

namespace CCSEPAssignment.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/<controller>
        [Route("api/Values/Get/{id}")]
        [HttpGet]
        public string Get(int id)
        {
            Debug.WriteLine("\n" + "TestGet" + "\n");
           // Debug.WriteLine("\n" + DatabaseModel.getDatabase().get(id) + "\n");
            return DatabaseModel.getDatabase().get(id); 
        }

        // GET api/<controller>
        [Route("api/Values/Update/")]
        [HttpGet]
        public List<Data> UpdateDB()
        {
            Debug.WriteLine("\n" + "Retrieving all entries" + "\n");
            return DatabaseModel.getDatabase().getData();
        }

        // GET api/<controller>
        [Route("api/Values/printDB/")]
        [HttpGet]
        public void PrintDB()
        {
            Debug.WriteLine("\n" + "PrintDBTest" + "\n");
            DatabaseModel.getDatabase().PrintDatabase();
        }

        // GET api/<controller>
        [Route("api/Values/GetCount/")]
        [HttpGet]
        public int GetCount()
        {
            Debug.WriteLine("\n" + "TestGetCount" + "\n");
            return DatabaseModel.getDatabase().getNumOfEntries();
        }

        // POST api/<controller>
        [Route("api/Values/Add/")]
        [HttpPost]
        public bool Post([FromBody]Data data)
        {
            Debug.WriteLine("\n" + "Added to DB: Username - " + data.username + " Password - " + data.password + "\n");
            return DatabaseModel.getDatabase().add(data.username, data.password);
        }
    }
}