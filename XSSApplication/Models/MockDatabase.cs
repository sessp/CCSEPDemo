using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace CCSEPAssignment.Models
{
    public class MockDatabase
    {
        private static MockDatabase db = null;
        private List<AccountData> entries;
        private MockDatabase()
        {
            entries = new List<AccountData>();
        }

        public static MockDatabase getDB()
        {
            if (db == null)
            {
                db = new MockDatabase();
            }
            return db;
        }

        public String getUsername(int i)
        {
            Debug.WriteLine("\n" + "TestGetUsername" + "\n");
            Debug.WriteLine("\n" + entries.First().username + "\n");
            return entries[i].username;
        }

        public List<AccountData> getData()
        {
            return entries;
        }

        public String getPassword(int i)
        {
            Debug.WriteLine("\n" + "TestGetDB" + "\n");
            Debug.WriteLine("\n" + entries.First().password + "\n");
            return entries[i].password;
        }

        public void PrintDatabase()
        {
            //For testing purposes.
            foreach (var v in entries)
            {
                Debug.WriteLine("\n" + "Entry U - " + v.username + " P- " + v.password + "\n");
            }
        }

        public int getNumOfEntries()
        {
            return entries.Count;
        }

        public bool add(string u, string p)
        {
            bool result = false;
            if (u != "admin" && p != "admin")
            {
                Debug.WriteLine("\n" + "Adding to DB" + "\n");
                Debug.WriteLine("\n" + u + " " + p + "\n");
                AccountData data = new AccountData();
                data.username = u;
                data.password = p;
                entries.Add(data);

            }
            else
            {
                result = true;
            }
            return result;

        }
    }
}