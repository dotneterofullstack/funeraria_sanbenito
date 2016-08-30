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
    public class ClientesController : ApiController
    {
        IDao dao;

        public ClientesController()
        {
            dao = DaoHelper.DaoFactory(typeof(ClienteDAO));
        }

        public IEnumerable<IModel> Get([FromUri]ClienteFilter filter)
        {
            IEnumerable<IModel> clientes = null;

            if (filter.ID == 0)
            {
                try
                {
                    clientes = dao.GetAll();
                }
                catch (Exception e)
                {
                    throw new HttpResponseException(HttpStatusCode.InternalServerError);
                }

                if (clientes.Count() <= 0)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
            }
            else
            {
                // Validar que esté solicitando un cliente válido
                if (filter.ID < 0)
                {
                    var response = new HttpResponseMessage()
                    {
                        StatusCode = (HttpStatusCode)422, //Entidad Inprocesable
                        ReasonPhrase = "Identificador de Cliente invalido"
                    };

                    throw new HttpResponseException(response);
                }

                try
                {
                    clientes = dao.GetByFilter(filter);
                }
                catch (Exception e)
                {
                    throw new HttpResponseException(HttpStatusCode.InternalServerError);
                }
            }
            return clientes;
        }

        public HttpResponseMessage Post(Cliente cliente)
        {
            HttpResponseMessage response = null;
            try
            {
                int resultado = dao.Save(cliente);
                if (resultado > 0)
                {
                    cliente.ID = resultado;
                    response = Request.CreateResponse<Cliente>(HttpStatusCode.Created, cliente);
                    string uri = Url.Link("DefaultApi", new { id = cliente.ID });
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
