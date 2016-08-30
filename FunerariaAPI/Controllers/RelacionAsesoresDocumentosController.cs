using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Funeraria.DAL.DAO;
using Funeraria.DAL.Models;
using Funeraria.API.Helpers;

namespace Funeraria.API.Controllers
{
    public class RelacionAsesoresDocumentosController : ApiController
    {
        IDao dao;
        public RelacionAsesoresDocumentosController()
        {
            dao = DaoHelper.DaoFactory(typeof(RelacionAsesoresDocumentosDAO));
        }

        public IEnumerable<IModel> Get([FromUri]RelacionAsesoresDocumentosFilter filter)
        {
            IEnumerable<IModel> reldoc = null;

                // Validar que esté solicitando un estado válido
                if (filter.IdAsesor <= 0)
                {
                    var response = new HttpResponseMessage()
                    {
                        StatusCode = (HttpStatusCode)422, //Entidad Inprocesable
                        ReasonPhrase = "Id de Asesor Invalido"
                    };

                    throw new HttpResponseException(response);
                }

                try
                {
                    reldoc = dao.GetByFilter(filter);
                }
                catch (Exception e)
                {
                    throw new HttpResponseException(HttpStatusCode.InternalServerError);
                }
            
            return reldoc;
        }
    }
}
