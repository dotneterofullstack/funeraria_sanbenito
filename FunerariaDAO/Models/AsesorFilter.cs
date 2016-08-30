using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funeraria.DAL.Models
{
    public class AsesorFilter : IFilter
    {
        public int ID { get; set; }
        public int IdCargo { get; set; }
        public int IdAsesorInvita { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPat { get; set; }
        public string ApellidoMat { get; set; }
        public string RFC { get; set; }

        public AsesorFilter()
        {
            Nombre = string.Empty;
            ApellidoMat = string.Empty;
            ApellidoPat = string.Empty;
            RFC = string.Empty;
        }
    }

}
