using Ejemplos.EntityFramework.ConsoleApplication.Cuentas;
using System.Web.Mvc;

namespace Ejemplos.EntityFramework.WebApplication.Controllers
{
    public class CuentasController : Controller
    {
        public ActionResult Index()
        {
            Escenario.AgregueUnaCuenta("Cuenta1", 1, 1);
            Escenario.AgregueUnaCuenta("Cuenta2", 2, 1);
            Escenario.AgregueUnaCuenta("Cuenta3", 3, 2);
            Escenario.AgregueUnaCuenta("Cuenta4", 4, 19);
            Escenario.EditeLaCuenta(1, 1, "Cuenta1 Nueva");
            Escenario.EditeLaCuenta(1, 1, "Cuenta1 Nueva Nueva");
            Escenario.EditeLaCuenta(2, 1, "Cuenta2 Nueva");
            Escenario.EditeLaCuenta(4, 19, "Cuenta4 Nueva");
            Escenario.EditeLaCuenta(4, 19, "Cuenta4 Nueva Nueva");

            return View();
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