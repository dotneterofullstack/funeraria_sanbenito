using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funeraria.DAL.Models
{
    public class Municipio: IModel
    {
        public int ID { get; set; }
        public int IdEstado { get; set; }
        public string Nombre { get; set; }
    }
}
