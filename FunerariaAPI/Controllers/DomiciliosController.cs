using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Funeraria.DAL.DAO;
using Funeraria.DAL.Models;
using Funeraria.API.Helpers;
using Funeraria.DAL.Enums;

namespace Funeraria.API.Controllers
{
    public class DomiciliosController : ApiController
    {
        IDao dao;

        public DomiciliosController()
        {
            dao = DaoHelper.DaoFactory(typeof(DomiciliosDAO));
        }

        public IEnumerable<IModel> Get([FromUri]DomicilioFilter filter)
        {
            IEnumerable<IModel> domicilios = null;
            ((DomiciliosDAO)dao).Propietario = filter.TipoPropietario;

            try
            {
                domicilios = dao.GetByFilter(filter);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }

            if (domicilios.Count() <= 0)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return domicilios;
        }
    }
}
