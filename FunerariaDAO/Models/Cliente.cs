using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Funeraria.DAL.Models
{
    public class Cliente: IModel
    {
        [Required(ErrorMessage = "Proporcione un ID de Cliente")]
        [Range(0, int.MaxValue)]
        public int ID { get; set; }

        [Required(ErrorMessage = "Proporcione un Nombre propio")]
        [StringLength(maximumLength: 100, MinimumLength = 1)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Proporcione el Apellido Paterno")]
        [StringLength(maximumLength: 100, MinimumLength = 1)]
        public string ApellidoPat { get; set; }

        [Required(ErrorMessage = "Proporcione el Apellido Materno")]
        [StringLength(maximumLength: 100, MinimumLength = 1)]
        public string ApellidoMat { get; set; }

        [StringLength(maximumLength: 20, MinimumLength = 1)]
        public string RFC { get; set; }

        [Required(ErrorMessage = "Proporcione el / los Domicilio(s) del cliente")]
        public IEnumerable<Domicilio> Domicilios { get; set; }

        [Required(ErrorMessage = "Proporcione el / los Teléfono(s) del cliente")]
        public IEnumerable<Telefono> Telefonos { get; set; }
    }
}
