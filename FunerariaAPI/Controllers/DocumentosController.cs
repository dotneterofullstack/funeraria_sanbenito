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
    public class DocumentosController : ApiController
    {
        IDao dao;

        public DocumentosController()
        {
            dao = DaoHelper.DaoFactory(typeof(DocumentosDAO));
        }

        public IEnumerable<IModel> Get()
        {
            IEnumerable<IModel> documentos = null;
            try
            {
                documentos = dao.GetAll();
            }
            catch (Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }

            if (documentos.Count() <= 0)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return documentos;
        }
    }
}
