using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using WebApplication05_T5AM.Models;

namespace WebApplication05_T5AM.DAO
{
    public class clienteDAO
    {
        conexionDAO cn = new conexionDAO();

        public IEnumerable<Cliente> listado()
        {
            {
                List<Cliente> temporal = new List<Cliente>();

                using (cn.getcn)
                {
                    SqlCommand cmd = new SqlCommand("usp_cliente_listado", cn.getcn);
                   
                    cn.getcn.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {

                        temporal.Add(new Cliente()
                        {
                            idcliente=dr.GetString(0),
                            nombrecia=dr.GetString(1),
                            direccion=dr.GetString(2),
                            idpais=dr.GetString(3),
                            telefono=dr.GetString(4)
                        });
                    }
                    dr.Close();
                    cn.getcn.Close();
                }

                return temporal;
            }
        }

        public IEnumerable<Cliente> listado(String sp, SqlParameter[]pars=null)
        {
            {
                List<Cliente> temporal = new List<Cliente>();

                using (cn.getcn)
                {
                    SqlCommand cmd = new SqlCommand(sp, cn.getcn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (pars != null) cmd.Parameters.AddRange(pars.ToArray());

                    cn.getcn.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {

                        temporal.Add(new Cliente()
                        {
                            idcliente = dr.GetString(0),
                            nombrecia = dr.GetString(1),
                            direccion = dr.GetString(2),
                            idpais = dr.GetString(3),
                            telefono = dr.GetString(4)
                        });
                    }
                    dr.Close();
                    cn.getcn.Close();
                }

                return temporal;
            }
        }

        public Cliente Buscar(String id)
        {
            //retornar el registro de clientes por id
            Cliente reg = listado().Where(c => c.idcliente == id).FirstOrDefault();
            return reg;
        }

        public String CRUD(string sp, SqlParameter[]pars=null,int op = 0)
        {
            string mensaje = "";

            try
            {
                SqlCommand cmd = new SqlCommand(sp,cn.getcn);
                cmd.CommandType = CommandType.StoredProcedure;

                if (pars != null) cmd.Parameters.AddRange(pars.ToArray());
                cn.getcn.Open();

                int c = cmd.ExecuteNonQuery(); //ejecutamos el CRUD
                if (op == 1) mensaje = c + "registro agregado";
                else if (op == 2) mensaje = c + "registro actualizado";
                else if (op == 3) mensaje = c + "registro eliminado";
            }
            catch(SqlException e){
                mensaje = e.Message;
            }
            finally
            {
                cn.getcn.Close();
            }

            return mensaje;
        }
    }
}