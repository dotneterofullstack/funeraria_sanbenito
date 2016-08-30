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
    public class CargosDAO: IDao
    {
        protected override string SP_DELETE_STR { get { return string.Empty; } }
        protected override string SP_GETALL_STR { get { return "seleccionar_cargos"; } }
        protected override string SP_GETBYFILTER_STR { get { return string.Empty; } }
        protected override string SP_GETBYID_STR { get { return string.Empty; } }
        protected override string SP_SAVE_STR { get { return "guardar_cargo"; } }

        protected override IModel BuildModel(IDataReader dataReader)
        {
            Cargo cargo = new Cargo();

            cargo.ID = dataReader.GetInt32(dataReader.GetOrdinal("ID"));
            cargo.Nombre = dataReader.GetString(dataReader.GetOrdinal("Nombre"));

            return cargo;
        }

        protected override SqlParameter[] BuildParameters(IModel IFilter, string strCommand)
        {
            Cargo cargo = (Cargo)IFilter;
            SqlParameter[] parametros = null;

            switch (strCommand)
            {
                case "guardar_cargo":
                    SqlParameter Nombre = new SqlParameter("@nombre", SqlDbType.VarChar);
                    Nombre.Value = cargo.Nombre;
                    Nombre.Direction = ParameterDirection.Input;

                    SqlParameter retval = new SqlParameter(RET_VAL_PARAM_NAME, SqlDbType.Int);
                    retval.Direction = ParameterDirection.ReturnValue;

                    parametros = new SqlParameter[] {
                        Nombre, retval
                    };
                    break;
            }

            return parametros;
        }

        protected override SqlParameter[] BuildParameters(IFilter IFilter, string strCommand)
        {
            throw new NotImplementedException();
        }
    }
}
