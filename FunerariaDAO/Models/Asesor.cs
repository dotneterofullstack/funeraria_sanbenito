using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Funeraria.DAL.Models
{
    public class Asesor: IModel
    {
        [Required(ErrorMessage = "Proporcione un ID de Asesor")]
        [Range(0, int.MaxValue)]
        public int ID { get; set; }

        [Required(ErrorMessage = "Proporcione un Cargo para el Asesor")]
        [Range(1, int.MaxValue)]
        public int IdCargo { get; set; }

        [Range(0, int.MaxValue)]
        public int IdAsesorInvita { get; set; }

        [Required(ErrorMessage = "Proporcione Código para el Asesor")]
        [StringLength(maximumLength: 10, MinimumLength = 1)]
        public string Codigo { get; set; }

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

        [Required(ErrorMessage = "Proporcione el / los Domicilio(s) del Asesor")]
        public IEnumerable<Domicilio> Domicilios { get; set; }

        [Required(ErrorMessage = "Proporcione el / los Teléfono(s) del Asesor")]
        public IEnumerable<Telefono> Telefonos { get; set; }

        [Required(ErrorMessage = "Proporcione los documentos asociados al Asesor")]
        public IEnumerable<RelacionAsesoresDocumentos> RelacionAsesoresDocumentos { get; set; }
    }
}
