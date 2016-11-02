using System;
using Ejemplos.EntityFramework.ConsoleApplication.Cuentas;

namespace Cuentas.WebApplication.Controllers
{
    public class CuentaVigenteVista
    {
        public CuentaVigenteVista(CuentaVigente unaCuenta)
        {
            Estado = unaCuenta.Estado;
            FechaDeActualizacion = unaCuenta.FechaDeActualizacion;
            IdEntidad = unaCuenta.IdEntidad;
            IdMoneda = unaCuenta.IdMoneda;
            Nombre = unaCuenta.Nombre;
        }

        public int Estado { get; private set; }
        public DateTime FechaDeActualizacion { get; private set; }
        public int IdEntidad { get; private set; }
        public int IdMoneda { get; private set; }
        public string Nombre { get; private set; }
    }
}