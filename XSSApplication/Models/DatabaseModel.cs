using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace CCSEPAssignment.Models
{
    public class DatabaseModel
    {
        private static DatabaseModel db = null;
        private List<Data> entries;
        private DatabaseModel()
        {
            entries = new List<Data>();
        }

        public static DatabaseModel getDatabase()
        {
            if (db == null)
            {
                Debug.WriteLine("\n" + "TestPrivateConstructor" + "\n");
                db = new DatabaseModel();
            }
            return db;
        }

        public String get(int i)
        {
            Debug.WriteLine("\n" + "TestGetDB" + "\n");
            Debug.WriteLine("\n" + entries.First().username + "\n");
            return entries.First().username;
        }

        public String getUsername(int i)
        {
            Debug.WriteLine("\n" + "TestGetUsername" + "\n");
            Debug.WriteLine("\n" + entries.First().username + "\n");
            return entries[i].username;
        }

        public List<Data> getData()
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
                Data data = new Data();
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