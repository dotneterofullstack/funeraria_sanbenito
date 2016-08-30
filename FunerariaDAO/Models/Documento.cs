using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funeraria.DAL.Models
{
    public class Documento: IModel
    {
        public int ID { get; set; }
        public string NombreDocumento { get; set; }
    }
}
