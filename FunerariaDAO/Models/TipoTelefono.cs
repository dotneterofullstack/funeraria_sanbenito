using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funeraria.DAL.Models
{
    public class TipoTelefono: IModel
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
    }
}
