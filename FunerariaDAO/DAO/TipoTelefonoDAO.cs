using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Funeraria.DAL.Models;

namespace Funeraria.DAL.DAO
{
    public class TipoTelefonoDAO: IDao
    {
        protected override string SP_DELETE_STR { get { return string.Empty; } }
        protected override string SP_GETALL_STR { get { return "seleccionar_tipos_telefono"; } }
        protected override string SP_GETBYFILTER_STR { get { return string.Empty; } }
        protected override string SP_GETBYID_STR { get { return string.Empty; } }
        protected override string SP_SAVE_STR { get { return string.Empty; } }


        protected override IModel BuildModel(IDataReader dataReader)
        {
            TipoTelefono tipoTelefono = new TipoTelefono();

            tipoTelefono.ID = dataReader.GetInt32(dataReader.GetOrdinal("ID"));
            tipoTelefono.Nombre = dataReader.GetString(dataReader.GetOrdinal("Nombre"));

            return tipoTelefono;
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
