using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funeraria.DAL.Models
{
    public class RelacionAsesoresDocumentos: IModel
    {
        public int ID { get; set; }
        public int IdAsesor { get; set; }
        public int IdDocumento { get; set; }
    }
}
