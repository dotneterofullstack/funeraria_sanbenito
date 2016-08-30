using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Funeraria.DAL.Models;
using Funeraria.DAL.DAO;
using System.Data;
using System.Data.SqlClient;

namespace Funeraria.DAL.DAO
{
    public class DocumentosDAO : IDao
    {
        protected override string SP_DELETE_STR
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        protected override string SP_GETALL_STR
        {
            get
            {
                return "seleccionar_documentos";
            }
        }

        protected override string SP_GETBYFILTER_STR
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        protected override string SP_GETBYID_STR
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        protected override string SP_SAVE_STR
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        protected override IModel BuildModel(IDataReader dataReader)
        {
            Documento documento = new Documento();

            documento.ID = dataReader.GetInt32(dataReader.GetOrdinal("ID"));
            documento.NombreDocumento = dataReader.GetString(dataReader.GetOrdinal("Documento"));

            return documento;
        }

        protected override SqlParameter[] BuildParameters(IModel IFilter, string strCommand)
        {
            throw new NotImplementedException();
        }

        protected override SqlParameter[] BuildParameters(IFilter IFilter, string strCommand)
        {
            throw new NotImplementedException();
        }
    }
}
