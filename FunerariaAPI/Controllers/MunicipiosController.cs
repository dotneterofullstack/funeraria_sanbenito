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
    public class MunicipiosController : ApiController
    {
        IDao dao;
        public MunicipiosController()
        {
            dao = DaoHelper.DaoFactory(typeof(MunicipioDAO));
        }

        public IEnumerable<IModel> Get([FromUri]MunicipioFilter filter)
        {
            IEnumerable<IModel> municipios = null;

            if (filter.IdEstado == 0)
            {
                try
                {
                    municipios = dao.GetAll();
                }
                catch (Exception e)
                {
                    throw new HttpResponseException(HttpStatusCode.InternalServerError);
                }

                if (municipios.Count() <= 0)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
            }
            else
            {
                // Validar que esté solicitando un estado válido
                if (filter.IdEstado < 0 || filter.IdEstado > 32)
                {
                    var response = new HttpResponseMessage()
                    {
                        StatusCode = (HttpStatusCode)422, //Entidad Inprocesable
                        ReasonPhrase = "Estado Invalido"
                    };

                    throw new HttpResponseException(response);
                }

                try
                {
                    municipios = dao.GetByFilter(filter);
                }
                catch (Exception e)
                {
                    throw new HttpResponseException(HttpStatusCode.InternalServerError);
                }
            }
            return municipios;
        }
    }
}
