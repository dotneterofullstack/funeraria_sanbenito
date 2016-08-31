using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funeraria.DAL.Models
{
    public class PagoServicioFunerario : IModel
    {
        public int ID { get; set; }
        public int IdServicioFunerario { get; set; }
        public int IdAsesorCobranza { get; set; }
        public TipoPagoServicioFunerario TipoPago { get; set; }
        public DateTime Fecha { get; set; }
        public string NumeroRecibo { get; set; }
        public decimal Abono { get; set; }
        public decimal Importe { get; set; }
        public decimal SaldoActual { get; set; }
        public string Observaciones { get; set; }
    }
}
