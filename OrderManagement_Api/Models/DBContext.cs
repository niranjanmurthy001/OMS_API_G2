using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Configuration;

namespace OrderManagement_Api.Models
{
    public class DBContext:DbContext
    {
     
        public DBContext()
        { 
            Database.Connection.ConnectionString = ConfigurationManager.ConnectionStrings["Title_Product_Connection"].ConnectionString;
        }

    }
}