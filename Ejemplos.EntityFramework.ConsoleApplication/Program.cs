using Ejemplos.EntityFramework.ConsoleApplication.Cuentas;

namespace Ejemplos.EntityFramework.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Escenario.EjecuteEscenarioDeAgregar();
            Escenario.EjecuteEscenarioDeAgregar();
            Escenario.EjecuteEscenarioDeEditar();
            Escenario.EjecuteEscenarioDeEditar();
            Escenario.EjecuteEscenarioDeEditar();

            Escenario.ImprimaTodasLasCuentasEHistoricos();
        }
    }
}
