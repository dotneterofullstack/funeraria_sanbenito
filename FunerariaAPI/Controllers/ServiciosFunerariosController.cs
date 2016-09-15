using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Net.Http;
using System.Web.Http;
using Funeraria.DAL.DAO;
using Funeraria.DAL.Models;
using Funeraria.API.Helpers;
using Funeraria.API.Filters;
using Newtonsoft.Json.Linq;

namespace Funeraria.API.Controllers
{
    public class ServiciosFunerariosController : ApiController
    {
        IDao dao;
        public ServiciosFunerariosController()
        {
            dao = DaoHelper.DaoFactory(typeof(ServicioFunerarioDAO));
        }

        public HttpResponseMessage Get([FromUri]ServicioFunerario filter)
        {
            string jsonStringResults;

            try
            {
                jsonStringResults = dao.GetJsonByFilter(filter);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
            HttpResponseMessage response = ConstruirHttpResponseMessageConJSON(jsonStringResults);
            return response;
        }

        private HttpResponseMessage ConstruirHttpResponseMessageConJSON(string jsonStringResults)
        {
            var response = new HttpResponseMessage();
            response.Content = new StringContent(jsonStringResults, Encoding.UTF8, "application/json");
            return response;
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