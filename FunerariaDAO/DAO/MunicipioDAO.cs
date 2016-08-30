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
    public class MunicipioDAO: IDao
    {
        protected override string SP_DELETE_STR { get { return string.Empty; } }
        protected override string SP_GETALL_STR { get { return "sp_select_municipios"; } }
        protected override string SP_GETBYFILTER_STR { get { return "sp_select_municipios_por_estado"; } }
        protected override string SP_GETBYID_STR { get { return string.Empty; } }
        protected override string SP_SAVE_STR { get { return string.Empty; } }


        protected override IModel BuildModel(IDataReader dataReader)
        {
            Municipio municipio = new Municipio();

            municipio.ID = dataReader.GetInt32(dataReader.GetOrdinal("ID"));
            municipio.IdEstado = dataReader.GetInt32(dataReader.GetOrdinal("IdEstado"));
            municipio.Nombre = dataReader.GetString(dataReader.GetOrdinal("Nombre"));

            return municipio;
        }

        protected override SqlParameter[] BuildParameters(IModel IFilter, string strCommand)
        {
            throw new NotImplementedException();
        }

        protected override SqlParameter[] BuildParameters(IFilter IFilter, string strCommand)
        {
            SqlParameter[] parametros = null;
            MunicipioFilter mpoFilter = (MunicipioFilter)IFilter;

            switch (strCommand)
            {
                case "sp_select_municipios_por_estado":
                    SqlParameter IdEstadoParam = new SqlParameter("@id", SqlDbType.Int);
                    IdEstadoParam.Direction = ParameterDirection.Input;
                    IdEstadoParam.Value = mpoFilter.IdEstado;

                    parametros = new SqlParameter[] {
                        IdEstadoParam
                    };
                    break;
            }

            return parametros;
        }
    }
}
