using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Funeraria.DAL.Models;

namespace Funeraria.DAL.DAO
{
    public class EstadoDAO : IDao
    {
        protected override string SP_DELETE_STR { get { return string.Empty; } }
        protected override string SP_GETALL_STR { get { return "sp_select_estados"; } }
        protected override string SP_GETBYFILTER_STR { get { return string.Empty; } }
        protected override string SP_GETBYID_STR {get { return string.Empty; } }
        protected override string SP_SAVE_STR { get { return string.Empty; }}

        protected override IModel BuildModel(IDataReader dataReader)
        {
            Estado estado = new Estado();

            estado.ID = dataReader.GetInt32(dataReader.GetOrdinal("ID"));
            estado.Abreviatura = dataReader.GetString(dataReader.GetOrdinal("Abreviatura"));
            estado.Nombre = dataReader.GetString(dataReader.GetOrdinal("Nombre"));

            return estado;
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
