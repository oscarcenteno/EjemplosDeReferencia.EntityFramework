using Ejemplos.EntityFramework.ConsoleApplication.Cuentas;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace EjemplosDeReferencia.EF.ConsoleApplication.Cuentas
{
    public static class Escenario
    {
        public static void EjecuteEscenarioDeAgregar()
        {
            Console.WriteLine(string.Empty);
            Console.WriteLine("** AGREGAR **");

            Console.Write("Escriba el nombre para la nueva Cuenta: ");
            string elNombre = Console.ReadLine();

            Console.Write("Escriba el Id de la Entidad: ");
            string elIdDeEntidad = Console.ReadLine();
            int elIdEntidadComoNumero = int.Parse(elIdDeEntidad);

            Console.Write("Escriba el Id de la Moneda: ");
            string elIdDeMoneda = Console.ReadLine();
            int elIdMonedaComoNumero = int.Parse(elIdDeMoneda);

            AgregueUnaCuenta(elNombre, elIdEntidadComoNumero, elIdMonedaComoNumero);

            ImprimaTodasLasCuentasEHistoricos();
        }

        public static void ImprimaTodasLasCuentasEHistoricos()
        {
            using (var db = new CuentasContext())
            {
                var lasCuentas = from cadaCuenta in db.Cuentas
                                 select cadaCuenta;

                Console.WriteLine(string.Empty);
                Console.WriteLine("CONSULTANDO Todas las cuentas y sus historicos:");

                foreach (var unaCuenta in lasCuentas)
                {
                    Console.WriteLine(unaCuenta.IdEntidad + " " + unaCuenta.IdMoneda);

                    var losHistoricos = from cadaHistorico in unaCuenta.Historicos
                                        select cadaHistorico;
                    foreach (var unHistorico in losHistoricos)
                    {
                        Console.WriteLine(" - " + unHistorico.Nombre + " " + unHistorico.Estado + " " + unHistorico.FechaDeModificacion);
                    }
                }
            }

            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
        }

        public static void AgregueUnaCuenta(string elNombre, int elIdEntidadComoNumero, int elIdDeMonedaComoNumero)
        {
            using (var db = new CuentasContext())
            {
                var laCuenta = new Cuenta
                {
                    IdEntidad = elIdEntidadComoNumero,
                    IdMoneda = elIdDeMonedaComoNumero
                };

                var elHistorico = new Historico
                {
                    Nombre = elNombre,
                    FechaDeModificacion = DateTime.Now,
                    Estado = 1
                };

                laCuenta.Agregue(elHistorico);
                db.Cuentas.Add(laCuenta);
                db.SaveChanges();
            }
        }

        public static void EjecuteEscenarioDeEditar()
        {
            Console.WriteLine(string.Empty);
            Console.WriteLine("** EDITAR **");
            Console.Write("Escriba el Id de la Entidad: ");
            string elIdDeEntidad = Console.ReadLine();
            int elIdDeEntidadComoNumero = int.Parse(elIdDeEntidad);

            Console.Write("Escriba el Id de la Moneda: ");
            string elIdMoneda = Console.ReadLine();
            int elIdMonedaComoNumero = int.Parse(elIdMoneda);

            Console.Write("Escriba el nuevo nombre para la Cuenta a editar: ");
            string elNombre = Console.ReadLine();

            EditeLaCuenta(elIdDeEntidadComoNumero, elIdMonedaComoNumero, elNombre);

            ImprimaLosDatosActuales();

            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
        }

        private static void ImprimaLosDatosActuales()
        {
            Console.WriteLine("CONSULTANDO los datos actuales de cada cuenta:");
            var lasCuentas = ListeLasCuentas();

            foreach (var unaCuenta in lasCuentas)
            {
                Console.WriteLine(unaCuenta.IdEntidad + " " + unaCuenta.IdMoneda + " " + unaCuenta.Nombre + " " + unaCuenta.Estado + " " + unaCuenta.FechaDeActualizacion);
            }
        }

        public static IEnumerable<CuentaVigente> ListeLasCuentas()
        {
            IEnumerable<CuentaVigente> lasCuentas;
            using (var elContexto = new CuentasContext())
            {
                DbSet<Cuenta> todasLasCuentas = ObtengaTodasLasCuentas(elContexto);
                lasCuentas = ObtengaLasCuentasAplanadas(todasLasCuentas);
            }

            return lasCuentas;
        }

        private static DbSet<Cuenta> ObtengaTodasLasCuentas(CuentasContext elContexto)
        {
            return elContexto.Cuentas;
        }

        private static IEnumerable<CuentaVigente> ObtengaLasCuentasAplanadas(IQueryable<Cuenta> lasCuentas)
        {
            // Obtenga las cuentas aplanadas con el historico mas reciente
            IEnumerable<CuentaVigente> laConsulta;
            laConsulta = from cadaCuenta in lasCuentas
                         let losHistoricos = cadaCuenta.Historicos
                         let losOrdenados = losHistoricos.OrderByDescending(unHistorico => unHistorico.FechaDeModificacion)
                         let elMasReciente = losOrdenados.FirstOrDefault()
                         select new CuentaVigente()
                         {
                             IdEntidad = cadaCuenta.IdEntidad,
                             IdMoneda = cadaCuenta.IdMoneda,
                             Nombre = elMasReciente.Nombre,
                             FechaDeActualizacion = elMasReciente.FechaDeModificacion,
                             Estado = elMasReciente.Estado
                         };

            return laConsulta.ToList();
        }

        public static void EditeLaCuenta(int elIdDeEntidadComoNumero, int elIdMonedaComoNumero, string elNombre)
        {
            using (var db = new CuentasContext())
            {
                Cuenta laCuenta;
                laCuenta = (from unaCuenta in db.Cuentas
                            where unaCuenta.IdEntidad.Equals(elIdDeEntidadComoNumero)
                            && unaCuenta.IdMoneda.Equals(elIdMonedaComoNumero)
                            select unaCuenta).First();

                var elNuevoHistorico = new Historico
                {
                    Nombre = elNombre,
                    FechaDeModificacion = DateTime.Now,
                    Estado = 2
                };

                laCuenta.Agregue(elNuevoHistorico);
                db.SaveChanges();
            }
        }
    }
}
