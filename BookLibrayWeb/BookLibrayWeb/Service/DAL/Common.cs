using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace BookLibrayWeb.Service.DAL
{
    public class Common
    {
        public static string GetConnectionString()
        {
            //Data Source=(local);  or Data Source=.\SQLExpress;
            return @"Data Source=(local); User ID=booksUser; Password=books;  Initial Catalog=BookLibraryDB; Persist Security Info=True;";

        }
    }
}