using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Funeraria.DAL.Models
{
    public class ServicioFunerario : IModel, IFilter
    {
        [Required(ErrorMessage = "Proporcione un ID de Servicio")]
        [Range(0, int.MaxValue)]
        public int ID { get; set; }

        [Required(ErrorMessage = "Proporcione un ID de Paquete")]
        [Range(0, int.MaxValue)]
        public int IdPaquete { get; set; }

        [Required(ErrorMessage = "Proporcione un ID de Asesor")]
        [Range(0, int.MaxValue)]
        public int IdAsesor { get; set; }

        [Required(ErrorMessage = "Proporcione un ID de Cliente")]
        [Range(0, int.MaxValue)]
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "Proporcione un ID de Domicilio de Cobranza")]
        [Range(0, int.MaxValue)]
        public int IdDomicilioCobranza { get; set; }

        [Required(ErrorMessage = "Proporcione una fecha de Solicitud")]
        public DateTime FechaSolicitud { get; set; }

        [Required(ErrorMessage = "Proporcione una fecha de Contrato")]
        public DateTime FechaContrato { get; set; }

        [Required(ErrorMessage = "Proporcione un Número de Contrato")]
        [StringLength(maximumLength: 10, MinimumLength = 1)]
        public string NumeroContrato { get; set; }

        [Required(ErrorMessage = "Proporcione un Número de Solicitud")]
        [StringLength(maximumLength: 10, MinimumLength = 1)]
        public string NumeroSolicitud{ get; set; }

        [Required(ErrorMessage = "Proporcione un Costo del Servicio Funerario")]
        [Range(typeof(decimal), "1", "9999999.99")]
        public decimal Costo { get; set; }
        public string TitularSustituto { get; set; }

        [Required(ErrorMessage = "Proporcione la frecuencia de Abonos al Servicio")]
        public int IdFrecuenciaAbonos { get; set; }

        [Required(ErrorMessage = "Defina si el servicio ya ha sido proporcionado")]
        public bool ServicioYaProporcionado { get; set; }

        [Required(ErrorMessage = "Proporcione el estatus de cobranza del Servicio")]
        public EstatusCobranzaServicioFunerario EstatusCobranza { get; set; }
    }
}
