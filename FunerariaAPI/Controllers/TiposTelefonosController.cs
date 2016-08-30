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
    public class TiposTelefonosController : ApiController
    {
        IDao dao;

        public TiposTelefonosController()
        {
            dao = DaoHelper.DaoFactory(typeof(TipoTelefonoDAO));
        }

        public IEnumerable<IModel> Get()
        {
            IEnumerable<IModel> tipos = null;
            try
            {
                tipos = dao.GetAll();
            }
            catch (Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }

            if (tipos.Count() <= 0)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return tipos;
        }
    }
}
