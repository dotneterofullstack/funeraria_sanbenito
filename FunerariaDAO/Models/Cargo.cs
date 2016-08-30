using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Funeraria.DAL.Models
{
    public class Cargo: IModel
    {
        [Required(ErrorMessage = "Proporcione un ID de Cargo")]
        public int ID { get; set; }
        [Required(ErrorMessage = "Proporcione una Descripción del Cargo")]
        public string Nombre { get; set; }
    }
}
