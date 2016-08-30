using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Funeraria.DAL.DAO;

namespace Funeraria.API.Helpers
{
    public class DaoHelper
    {
        public static IDao DaoFactory(Type type)
        {
            IDao dao = null;

            if (type == typeof(EstadoDAO))
            {
                dao = new EstadoDAO();
            }
            else if (type == typeof(MunicipioDAO))
            {
                dao = new MunicipioDAO();
            }
            else if (type == typeof(FrecuenciaAbonoDAO))
            {
                dao = new FrecuenciaAbonoDAO();
            }
            else if (type == typeof(PaqueteServicioDAO))
            {
                dao = new PaqueteServicioDAO();
            }
            else if (type == typeof(TipoTelefonoDAO))
            {
                dao = new TipoTelefonoDAO();
            }
            else if (type == typeof(ClienteDAO))
            {
                dao = new ClienteDAO();
            }
            else if (type == typeof(AsesorDAO))
            {
                dao = new AsesorDAO();
            }
            else if (type == typeof(DocumentosDAO))
            {
                dao = new DocumentosDAO();
            }
            else if (type == typeof(DomiciliosDAO))
            {
                dao = new DomiciliosDAO();
            }
            else if (type == typeof(TelefonosDAO))
            {
                dao = new TelefonosDAO();
            }
            else if (type == typeof(RelacionAsesoresDocumentosDAO))
            {
                dao = new RelacionAsesoresDocumentosDAO();
            }
            else if (type == typeof(CargosDAO))
            {
                dao = new CargosDAO();
            }
            else
            {
                throw new Exception("Tipo de Dao Desconocido: " + type.ToString());
            }

            dao.SqlConString = WebConfigHelper.GetConnectionString();
            return dao;
        }
    }
}
