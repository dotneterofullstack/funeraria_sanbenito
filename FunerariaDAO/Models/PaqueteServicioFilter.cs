using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funeraria.DAL.Models
{
    public class PaqueteServicioFilter: IFilter
    {
        public int IdPaquete { get; set; }
        public bool? SoloCremacion { get; set; }
    }
}
