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
    public class AsesoresController : ApiController
    {
        IDao dao;

        public AsesoresController()
        {
            dao = DaoHelper.DaoFactory(typeof(AsesorDAO));
        }

        public IEnumerable<IModel> Get([FromUri]AsesorFilter filter)
        {
            IEnumerable<IModel> asesores = null;

            // Validar que esté solicitando un asesor válido
            if (filter.ID < 0)
            {
                var response = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422, //Entidad Inprocesable
                    ReasonPhrase = "Identificador de Asesor invalido"
                };

                throw new HttpResponseException(response);
            }

            try
            {
                asesores = dao.GetByFilter(filter);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
            
            return asesores;
        }

        [ValidateModel]
        public HttpResponseMessage Post(Asesor asesor)
        {
            HttpResponseMessage response = null;
            try
            {
                int resultado = dao.Save(asesor);
                if (resultado > 0)
                {
                    asesor.ID = resultado;
                    response = Request.CreateResponse<Asesor>(HttpStatusCode.Created, asesor);
                    string uri = Url.Link("DefaultApi", new { id = asesor.ID });
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
