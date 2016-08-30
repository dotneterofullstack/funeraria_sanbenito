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
    public class EstadosController : ApiController
    {
        IDao dao;
        public EstadosController()
        {
            dao = DaoHelper.DaoFactory(typeof(EstadoDAO));
        }

        public IEnumerable<IModel> Get()
        {
            IEnumerable<IModel> estados = null;
            try
            {
                estados = dao.GetAll();
            }
            catch (Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
            
            if (estados.Count() <= 0)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return estados;
        }
    }
}
