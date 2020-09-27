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
            Debug.WriteLine("\n" + entries.First().d + "\n");
           return entries.First().d;
        }

        public void add(string s)
        {
            Debug.WriteLine("\n" + "TestAddDB" + "\n");
            Debug.WriteLine("\n" + s + "\n");
            Data data = new Data();
            data.d = s;
            entries.Add(data);
        }
    }
}