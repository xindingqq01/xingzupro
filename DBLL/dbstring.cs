using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace DBLL
{
    public class dbstring
    {
        public static string dbconnectionstring = ConfigurationManager.ConnectionStrings["dbcon"].ToString();
    }
}
