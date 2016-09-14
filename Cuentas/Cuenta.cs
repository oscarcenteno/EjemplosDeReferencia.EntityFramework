using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EjemplosDeReferencia.EF.ConsoleApplication.Cuentas
{
    public class Cuenta
    {
        public Cuenta()
        {
            Historicos = new List<Historico>();
        }

        [Key, Column(Order = 0)]
        public int IdEntidad { get; set; }
        [Key, Column(Order = 1)]
        public int IdMoneda { get; set; }

        public virtual List<Historico> Historicos { get; set; }

        internal void Agregue(Historico elNuevoHistorico)
        {
            Historicos.Add(elNuevoHistorico);
        }
    }
}
