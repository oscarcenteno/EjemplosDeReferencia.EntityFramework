using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemplosDeReferencia.EF.ConsoleApplication.Cuentas
{
    public class Historico
    {
        [Key]
        public int IdHistorico { get; set; }
        public string Nombre { get; set; }
        public int Estado { get; set; }
        public DateTime FechaDeModificacion { get; set; }

        public int IdEntidad { get; set; }
        public int IdMoneda { get; set; }

        [ForeignKey("IdEntidad, IdMoneda")]
        public virtual Cuenta Cuenta { get; set; }
    }

}
