using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Funeraria.DAL.Enums;

namespace Funeraria.DAL.Models
{
    public class DomicilioFilter : IFilter
    {
        public int IdPropietario { get; set; }
        public PropietarioEnum TipoPropietario { get; set; }
    }
}
