using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using WebApplication05_T5AM.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Sql;

namespace WebApplication05_T5AM.DAO
{
    public class conexionDAO
    {

        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);

        public SqlConnection getcn{
            get{ return cn; }
            }
        
    }
}