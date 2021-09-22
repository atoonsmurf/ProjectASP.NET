using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using WebApplication05_T5AM.Models;

namespace WebApplication05_T5AM.DAO
{
    public class paisDAO
    {
        conexionDAO cn = new conexionDAO();

        public IEnumerable<Pais> listado()
        {
            {
                List<Pais> temporal = new List<Pais>();

                using (cn.getcn)
                {
                    SqlCommand cmd = new SqlCommand("usp_pais_listado", cn.getcn);
                    
                    cn.getcn.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {

                        temporal.Add(new Pais()
                        {
                            idpais= dr.GetString(0),
                            nombrepais=dr.GetString(1)
                        });
                    }
                    dr.Close();
                    cn.getcn.Close();
                }

                return temporal;
            }
        }

        public IEnumerable<Pais> listado(String sp, SqlParameter[] pars=null)
        {
            {
                List<Pais> temporal = new List<Pais>();

                using (cn.getcn)
                {
                    SqlCommand cmd = new SqlCommand(sp, cn.getcn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (pars != null) cmd.Parameters.AddRange(pars.ToArray());

                    cn.getcn.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {

                        temporal.Add(new Pais()
                        {
                            idpais = dr.GetString(0),
                            nombrepais = dr.GetString(1)
                        });
                    }
                    dr.Close();
                    cn.getcn.Close();
                }

                return temporal;
            }
        }
    }
}