using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Funeraria.DAL.Models
{
    public class PaqueteServicio: IModel
    {
        [Required(ErrorMessage = "Proporcione un ID de Paquete")]
        [Range(0, int.MaxValue)]
        public int ID { get; set; }

        [Required(ErrorMessage = "Proporcione una descripción para el Paquete")]
        [StringLength(maximumLength: 250, MinimumLength = 1)]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Proporcione un Precio de Paquete")]
        [Range(typeof(decimal), "1", "9999999.99")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "Proporcione el valor de la comisión para el Asesor")]
        [Range(typeof(decimal), "1", "9999999.99")]
        public decimal Comision { get; set; }

        [Required(ErrorMessage = "Especifique si el Paquete es Sólo Cremación")]
        public bool SoloCremacion { get; set; }
    }
}
