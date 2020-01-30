using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ServiceDesk.Helper
{
    public class Config
    {
        public static string SqlConnStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    }
}