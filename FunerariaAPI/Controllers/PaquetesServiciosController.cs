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
    public class PaquetesServiciosController : ApiController
    {
        IDao dao;

        public PaquetesServiciosController()
        {
            dao = DaoHelper.DaoFactory(typeof(PaqueteServicioDAO));
        }

        [ValidateModel]
        public HttpResponseMessage Post(PaqueteServicio paquete)
        {
            HttpResponseMessage response = null;
            try
            {
                int resultado = dao.Save(paquete);
                if (resultado > 0)
                {
                    paquete.ID = resultado;
                    response = Request.CreateResponse<PaqueteServicio>(HttpStatusCode.Created, paquete);
                    string uri = Url.Link("DefaultApi", new { id = paquete.ID });
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

        public IEnumerable<IModel> Get([FromUri] PaqueteServicioFilter filtro)
        {
            IEnumerable<IModel> paquetes = null;

            if (filtro.IdPaquete < 0)
            {
                var response = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422, //Entidad Inprocesable
                    ReasonPhrase = "Identificador de Paquete invalido"
                };

                throw new HttpResponseException(response);
            }

            if (filtro.IdPaquete > 0 || filtro.SoloCremacion.HasValue)
            {
                try
                {
                    paquetes = dao.GetByFilter(filtro);
                }
                catch (Exception e)
                {
                    throw new HttpResponseException(HttpStatusCode.InternalServerError);
                }

                if (paquetes.Count() <= 0)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
            }
            else
            {
                try
                {
                    paquetes = dao.GetAll();
                }
                catch (Exception e)
                {
                    throw new HttpResponseException(HttpStatusCode.InternalServerError);
                }

                if (paquetes.Count() <= 0)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
            }

            return paquetes;
        }
    }
}
