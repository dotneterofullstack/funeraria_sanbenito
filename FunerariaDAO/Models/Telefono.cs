using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Funeraria.DAL.Models
{
    public class Telefono: IModel
    {
        [Required(ErrorMessage = "Proporcione un ID de Teéfono")]
        [Range(0, int.MaxValue)]
        public int ID { get; set; }

        [Required(ErrorMessage = "Proporcione un ID de Propietario")]
        [Range(0, int.MaxValue)]
        public int IdPropietario { get; set; }

        [Required(ErrorMessage = "Proporcione un Tipo de Teléfono")]
        [Range(0, int.MaxValue)]
        public int IdTipoTelefono { get; set; }

        [Required(ErrorMessage = "Proporcione un número de Teléfono")]
        [StringLength(maximumLength: 10, MinimumLength = 1)]
        public string NoTelefono { get; set; }

        //[StringLength(maximumLength: 5)]
        public string Extension { get; set; }
    }
}
