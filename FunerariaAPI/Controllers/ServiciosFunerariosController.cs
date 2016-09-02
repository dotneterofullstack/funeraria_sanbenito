using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Funeraria.DAL.DAO;
using Funeraria.DAL.Models;
using Funeraria.API.Helpers;
using Funeraria.API.Filters;

namespace Funeraria.API.Controllers
{
    public class ServiciosFunerariosController : ApiController
    {
        IDao dao;
        public ServiciosFunerariosController()
        {
            dao = DaoHelper.DaoFactory(typeof(ServicioFunerarioDAO));
        }

        public IEnumerable<IModel> Get([FromUri]ServicioFunerario filter)
        {
            IEnumerable<IModel> reldoc = null;

            // Validar que esté solicitando un estado válido
            if (filter.ID <= 0)
            {
                var response = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422, //Entidad Inprocesable
                    ReasonPhrase = "Id de Servicio Funerario Invalido"
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

        [ValidateModel]
        public HttpResponseMessage Post(ServicioFunerario servicioFunerario)
        {
            HttpResponseMessage response = null;
            try
            {
                int resultado = dao.Save(servicioFunerario);
                if (resultado > 0)
                {
                    servicioFunerario.ID = resultado;
                    response = Request.CreateResponse<ServicioFunerario>(HttpStatusCode.Created, servicioFunerario);
                    string uri = Url.Link("DefaultApi", new { id = servicioFunerario.ID });
                    response.Headers.Location = new Uri(uri);
                    return response;
                }
                else
                {
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                }
            }
            catch (Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }
    }
}