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
    public class TelefonosController : ApiController
    {
        IDao dao;

        public TelefonosController()
        {
            dao = DaoHelper.DaoFactory(typeof(TelefonosDAO));
        }

        public IEnumerable<IModel> Get([FromUri]TelefonoFilter filter)
        {
            IEnumerable<IModel> telefonos = null;
            ((TelefonosDAO)dao).Propietario = filter.TipoPropietario;

            try
            {
                telefonos = dao.GetByFilter(filter);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }

            if (telefonos.Count() <= 0)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return telefonos;
        }
    }
}
