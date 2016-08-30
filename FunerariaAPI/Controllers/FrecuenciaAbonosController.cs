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
    public class FrecuenciaAbonosController : ApiController
    {
        IDao dao;

        public FrecuenciaAbonosController()
        {
            dao = DaoHelper.DaoFactory(typeof(FrecuenciaAbonoDAO));
        }

        public IEnumerable<IModel> Get()
        {
            IEnumerable<IModel> frecuencias = null;
            try
            {
                frecuencias = dao.GetAll();
            }
            catch (Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }

            if (frecuencias.Count() <= 0)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return frecuencias;
        }
    }
}
