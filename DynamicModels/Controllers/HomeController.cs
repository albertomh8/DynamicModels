using DynamicModels.Models;
using DynamicModels.Repositories;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DynamicModels.Controllers
{
    public class HomeController : Controller
    {
        RepositoryDinamico repo;
        public HomeController()
        {
            repo = new RepositoryDinamico();
        }
        public ActionResult Index()
        {
            dynamic modelo = new ExpandoObject();
            modelo.Clientes = repo.CrearClientes();
            modelo.Pedidos = repo.CrearPedidos();
            
            return View(modelo);
        }

        public ActionResult ExpandoObj()
        {
            var item = new
            {
                PrimeraPropiedad = "Contenido primera propiedad",
                SegundaPropiedad = "Contenido segunda propiedad"
            };

            ViewBag.Obj = repo.ObjetoAnonimo(item);
            return View();
        }

        public ActionResult ColeccionExpando()
        {
            IQueryable<object>datosAnonimos = repo.ColeccionAnonima();
            dynamic datosExpando = repo.ListaAnonima(datosAnonimos);

            return View(datosExpando);
        }
    }
}