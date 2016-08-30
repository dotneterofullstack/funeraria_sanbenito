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
    public class CargosController : ApiController
    {
        IDao dao;
        public CargosController()
        {
            dao = DaoHelper.DaoFactory(typeof(CargosDAO));
        }

        [ValidateModel]
        public HttpResponseMessage Post(Cargo cargo)
        {
            HttpResponseMessage response = null;
            try
            {
                int resultado = dao.Save(cargo);
                if (resultado > 0)
                {
                    cargo.ID = resultado;
                    response = Request.CreateResponse<Cargo>(HttpStatusCode.Created, cargo);
                    string uri = Url.Link("DefaultApi", new { id = cargo.ID });
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

        public IEnumerable<IModel> Get()
        {
            IEnumerable<IModel> cargos = null;
            try
            {
                cargos = dao.GetAll();
            }
            catch (Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }

            if (cargos.Count() <= 0)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return cargos;
        }
    }
}
