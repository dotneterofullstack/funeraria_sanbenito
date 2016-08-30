using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Funeraria.DAL.Models
{
    public class Domicilio: IModel
    {
        [Required(ErrorMessage = "Proporcione un ID de Domicilio")]
        [Range(0, int.MaxValue)]
        public int ID { get; set; }

        [Required(ErrorMessage = "Proporcione un Municipio")]
        [Range(0, int.MaxValue)]
        public int IdMunicipio { get; set; }

        [Required(ErrorMessage = "Proporcione la Calle")]
        [StringLength(maximumLength: 200, MinimumLength = 1)]
        public string Calle { get; set; }

        [Required(ErrorMessage = "Proporcione el Número Exterior")]
        [StringLength(maximumLength: 10, MinimumLength = 1)]
        public string NumeroExterior { get; set; }

        [StringLength(maximumLength: 10, MinimumLength = 1)]
        public string NumeroInterior { get; set; }

        [Required(ErrorMessage = "Proporcione la Colónia")]
        [StringLength(maximumLength: 200, MinimumLength = 1)]
        public string Colonia { get; set; }

        [Required(ErrorMessage = "Proporcione el Código postal")]
        [StringLength(maximumLength: 10, MinimumLength = 1)]
        public string CodigoPostal { get; set; }

        [StringLength(maximumLength: 400, MinimumLength = 1)]
        public string EntreCalles { get; set; }

        [StringLength(maximumLength: 10, MinimumLength = 1)]
        public string Latitud { get; set; }

        [StringLength(maximumLength: 10, MinimumLength = 1)]
        public string Longitud { get; set; }

        public bool Cobranza { get; set; }
        public object IdPropietario { get; internal set; }
    }
}
