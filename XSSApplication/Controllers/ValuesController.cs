using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CCSEPAssignment.Models;
using System.Web.Security.AntiXss;
using RestSharp;
using Newtonsoft.Json;

namespace CCSEPAssignment.Controllers
{
    public class ValuesController : ApiController
    {
        private RestClient server = new RestClient("https://localhost:44378/");

        // GET api/<controller>
        [Route("api/Values/Update/")]
        [HttpGet]
        public List<AccountData> UpdateDB()
        {
            // return MockDatabase.getDB().getData();


            RestRequest req = new RestRequest("api/Values/Update/");
            IRestResponse response = server.Get(req);
            List<AccountData> newEntries = JsonConvert.DeserializeObject<List<AccountData>>(response.Content);
            
            return newEntries;
        }

        // GET api/<controller>
        [Route("api/Values/printDB/")]
        [HttpGet]
        public void PrintDB()
        {
            RestRequest req = new RestRequest("api/Values/printDB/");
            IRestResponse response = server.Get(req);

            //MockDatabase.getDB().PrintDatabase();
        }

        // GET api/<controller>
        [Route("api/Values/GetCount/")]
        [HttpGet]
        public int GetCount()
        {
            Debug.WriteLine("\n" + "TestGetCount" + "\n");
            //return MockDatabase.getDB().getNumOfEntries();


            RestRequest req = new RestRequest("api/Values/GetCount/");
            IRestResponse response = server.Get(req);
            int count = Convert.ToInt32(response.Content);
            return count;
        }

        // POST api/<controller>
        [Route("api/Values/Add/")]
        [HttpPost]
        public bool Post([FromBody]AccountData data)
        {
            CustomValidator validator = new CustomValidator();
            string validUsername = validator.antiXssValidation(data.username);
            string validPassword = validator.antiXssValidation(data.password);
            //string encodedUsername = AntiXssEncoder.HtmlEncode(validUsername, false);
            //string encodedPassword = AntiXssEncoder.HtmlEncode(validPassword, false); 
            //return MockDatabase.getDB().add(data.username, data.password);
            
            
            AccountData secureData = new AccountData();
            secureData.username = validUsername;
            secureData.password = validPassword;
            
            RestRequest req = new RestRequest("api/Values/Add/");
            req.AddJsonBody(secureData);
            IRestResponse response = server.Post(req);
            bool rStatus = Convert.ToBoolean(response.Content);
            
            return rStatus;
        }
    }
}