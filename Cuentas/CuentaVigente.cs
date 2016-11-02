using System;

namespace EjemplosDeReferencia.EF.ConsoleApplication.Cuentas
{
    public class CuentaVigente
    {
        public DateTime FechaDeActualizacion { get; internal set; }
        public int IdMoneda { get; internal set; }
        public int IdEntidad { get; internal set; }
        public string Nombre { get; internal set; }
        public int Estado { get; internal set; }
    }
}