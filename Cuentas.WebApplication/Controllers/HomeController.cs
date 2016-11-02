using EjemplosDeReferencia.EF.ConsoleApplication.Cuentas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cuentas.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Escenario.AgregueUnaCuenta("Cuenta1", 1, 1);
            Escenario.AgregueUnaCuenta("Cuenta2", 2, 1);
            Escenario.AgregueUnaCuenta("Cuenta3", 3, 2);
            Escenario.AgregueUnaCuenta("Cuenta4", 4, 19);
            Escenario.EditeLaCuenta(1, 1, "Cuenta1 Nueva");
            Escenario.EditeLaCuenta(1, 1, "Cuenta1 Nueva2");
            Escenario.EditeLaCuenta(2, 1, "Cuenta4 Nueva");
            Escenario.EditeLaCuenta(3, 2, "Cuenta4 Nueva");
            Escenario.EditeLaCuenta(4, 19, "Cuenta4 Nueva");

            IEnumerable<CuentaVigente>lasCuentas = Escenario.ListeLasCuentas();
            IEnumerable<CuentaVigenteVista> lasVistas = MapeeLasVistas(lasCuentas);

            return View(lasVistas);
        }

        private IEnumerable<CuentaVigenteVista> MapeeLasVistas(IEnumerable<CuentaVigente> lasCuentas)
        {
            List<CuentaVigenteVista> lasVistas = new List<CuentaVigenteVista>();

            foreach (CuentaVigente unaCuenta in lasCuentas)
            {
                CuentaVigenteVista laVista = new CuentaVigenteVista(unaCuenta);
                lasVistas.Add(laVista);
            }

            return lasVistas;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}