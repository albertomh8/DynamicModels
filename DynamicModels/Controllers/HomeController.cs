using DynamicModels.Repositories;
using System.Dynamic;
using System.Linq;
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
        public ActionResult ExpandoObj()
        {
            dynamic modelo = new ExpandoObject();
            modelo.Clientes = repo.CrearClientes();
            modelo.Pedidos = repo.CrearPedidos();
            
            return View(modelo);
        }

        public ActionResult ObjAnonimo()
        {
            var item = new
            {
                PrimeraPropiedad = "Contenido primera propiedad",
                SegundaPropiedad = "Contenido segunda propiedad",
                TerceraPropiedad = 23
            };

            var modelo = repo.ObjetoAnonimo(item);
            return View(modelo);
        }

        public ActionResult ColeccionExpando()
        {
            IQueryable<object> datosAnonimos = repo.ColeccionAnonima();
            dynamic datosExpando = repo.ListaAnonima(datosAnonimos);

            return View(datosExpando);
        }
    }
}