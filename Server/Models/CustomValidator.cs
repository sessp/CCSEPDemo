using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server.Models
{
    public class CustomValidator
    {
        public string antiXssValidation(string input)
        {

            if (input.Contains("<script>") || input.Contains("</script>"))
            {
                return "notvalid";
            }
            else
            {
                return input;
            }

        }
    }
}