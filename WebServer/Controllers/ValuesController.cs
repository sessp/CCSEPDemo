using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CCSEPAssignment.Models;
using System.Web.Security.AntiXss;
using Embarr.WebAPI.AntiXss;

namespace CCSEPAssignment.Controllers
{
    public class ValuesController : ApiController
    {

        // GET api/<controller>
        [Route("api/Values/Update/")]
        [HttpGet]
        public List<AccountData> UpdateDB()
        {
            return MockDatabase.getDB().getData();
        }

        // GET api/<controller>
        [Route("api/Values/printDB/")]
        [HttpGet]
        public void PrintDB()
        {
            MockDatabase.getDB().PrintDatabase();
        }

        // GET api/<controller>
        [Route("api/Values/GetCount/")]
        [HttpGet]
        public int GetCount()
        {
            Debug.WriteLine("\n" + "TestGetCount" + "\n");
            return MockDatabase.getDB().getNumOfEntries();
        }

        // POST api/<controller>
        [Route("api/Values/Add/")]
        [HttpPost]
        public bool Post([FromBody]AccountData data)
        {
            //CustomValidator validator = new CustomValidator();
            //string validiatedUsername = validator.antiXssValidation(data.username);
            //string validatedPassword = validator.antiXssValidation(data.password);
           // string encodedUsername = AntiXssEncoder.HtmlEncode(data.username, false);
           // string encodedPassword = AntiXssEncoder.HtmlEncode(data.password, false); 
            return MockDatabase.getDB().add(data.username, data.password);
        }
    }
}