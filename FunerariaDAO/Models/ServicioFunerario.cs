using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funeraria.DAL.Models
{
    public class ServicioFunerario : IFilter
    {
        public int ID { get; set; }
        public int IdPaquete { get; set; }
        public int IdAsesor { get; set; }
        public int IdCliente { get; set; }
        public int IdDomicilioCobranza { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public string NumeroContrato { get; set; }
        public string NumeroSolicitud{ get; set; }
        public decimal Costo { get; set; }
        public string TitularSustituto { get; set; }
        public int IdFrecuenciaAbonos { get; set; }
        public bool ServicioYaProporcionado { get; set; }
        public EstatusCobranzaServicioFunerario EstatusCobranza { get; set; }
    }
}
