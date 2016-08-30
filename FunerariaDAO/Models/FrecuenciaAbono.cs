using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funeraria.DAL.Models
{
    public class FrecuenciaAbono: IModel
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public int Dias { get; set; }
        public bool SoloDiasHabiles { get; set; }
    }
}
