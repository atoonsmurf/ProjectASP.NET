using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data.SqlClient;
using WebApplication05_T5AM.DAO;
using WebApplication05_T5AM.Models;


namespace WebApplication05_T5AM.Controllers
{
    public class NegociosController : Controller
    {
        // DAOS
        clienteDAO clientes = new clienteDAO();
        paisDAO paises = new paisDAO();

        public ActionResult Index()
        {
            return View(clientes.listado());
        }
       
        public ActionResult Create()
        {
            //enviar lista de paises(dropDown) y un nuevo cliente
            ViewBag.paises = new SelectList(
                paises.listado(),
                "idpais",
                "nombrepais");

            return View(new Cliente());
        }

        [HttpPost]
        public ActionResult Create(Cliente reg)
        {
            // lista de parametros
            SqlParameter[] pars =
            {
                new SqlParameter(){ParameterName="@idcli",Value=reg.idcliente},
                new SqlParameter(){ParameterName="@nombrecia",Value=reg.nombrecia},
                new SqlParameter(){ParameterName="@direccion",Value=reg.direccion},
                new SqlParameter(){ParameterName="@idpais",Value=reg.idpais},
                new SqlParameter(){ParameterName="@telefono",Value=reg.telefono}
            };

            //ejecutar
            ViewBag.mensaje = clientes.CRUD("usp_cliente_agregar", pars, 1);

            //al regresar refrescar la pagina
            ViewBag.paises = new SelectList(
                paises.listado(),
                "idpais",
                "nombrepais",
                reg.idpais
                );
            return View(reg);

        }

        public ActionResult Edit(String id = "")
        {
            Cliente reg = clientes.Buscar(id);

            if (reg == null)
                return RedirectToAction("Index");
            else
            {
                ViewBag.paises = new SelectList(paises.listado(),
                    "idpais",
                    "nombrepais",
                    reg.idpais);

                return View(reg);
            }

        }

        [HttpPost]
        public ActionResult Edit(Cliente reg)
        {
            SqlParameter[] pars={
                new SqlParameter() { ParameterName= "@idcli", Value=reg.idcliente},
                new SqlParameter() { ParameterName = "@nombrecia", Value = reg.nombrecia },
                new SqlParameter() { ParameterName = "@direccion", Value = reg.direccion },
                new SqlParameter() { ParameterName = "@idpais", Value = reg.idpais },
                new SqlParameter() { ParameterName = "@telefono", Value = reg.telefono }
            };

            ViewBag.mensaje = clientes.CRUD("usp_cliente_actualizar", pars, 2);

            ViewBag.paises = new SelectList(paises.listado(),
                "idpais",
                "nombrepais",
                reg.idpais);

            return View(reg);
        }
        
        public ActionResult Details(String id = "")
        {
            Cliente reg = clientes.Buscar(id);
            if (reg == null)
                return RedirectToAction("Index");
            else { 
                
                return View(reg); 
            }

    
            
        }

       public ActionResult Delete(String id = "")
        {
            Cliente reg = clientes.Buscar(id);

            if (reg == null)
                return RedirectToAction("Index");
            else
            {    
                return View(reg);
            }
        }

        [HttpPost]
        public ActionResult Delete(Cliente reg)
        {
            SqlParameter[] pars =
            {
                 new SqlParameter() { ParameterName= "@idcli", Value=reg.idcliente} 
            };

            ViewBag.mensaje = clientes.CRUD("usp_cliente_eliminar", pars, 3);


            return View(reg);
        }
      
    }

    

}