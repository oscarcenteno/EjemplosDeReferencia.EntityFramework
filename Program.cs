using EjemplosDeReferencia.EF.ConsoleApplication.Cuentas;

namespace EjemplosDeReferencia.EF.ConsoleApplication
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
