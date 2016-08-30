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
    public class PaqueteServicioDAO: IDao
    {
        protected override string SP_DELETE_STR { get { return string.Empty; } }
        protected override string SP_GETALL_STR { get { return "seleccionar_paquetes_servicio"; } }
        protected override string SP_GETBYFILTER_STR { get { return "seleccionar_paquetes_servicio"; } }
        protected override string SP_GETBYID_STR { get { return string.Empty; } }
        protected override string SP_SAVE_STR { get { return "guardar_paquete_servicio"; } }

        protected override IModel BuildModel(IDataReader dataReader)
        {
            PaqueteServicio paquete = new PaqueteServicio();

            paquete.ID = dataReader.GetInt32(dataReader.GetOrdinal("ID"));
            paquete.Descripcion = dataReader.GetString(dataReader.GetOrdinal("Descripcion"));
            paquete.Precio = dataReader.GetDecimal(dataReader.GetOrdinal("Precio"));
            paquete.Comision = dataReader.GetDecimal(dataReader.GetOrdinal("Comision"));
            paquete.SoloCremacion = dataReader.GetBoolean(dataReader.GetOrdinal("SoloCremacion"));

            return paquete;
        }

        protected override SqlParameter[] BuildParameters(IModel IFilter, string strCommand)
        {
            PaqueteServicio paquete = (PaqueteServicio)IFilter;
            SqlParameter[] parametros = null;

            switch (strCommand)
            {
                case "guardar_paquete_servicio":
                    SqlParameter idPaquete = new SqlParameter("@idPaquete", SqlDbType.Int);
                    idPaquete.Value = paquete.ID;
                    idPaquete.Direction = ParameterDirection.Input;

                    SqlParameter Descripcion = new SqlParameter("@Descripcion", SqlDbType.VarChar);
                    Descripcion.Value = paquete.Descripcion;
                    Descripcion.Direction = ParameterDirection.Input;

                    SqlParameter Precio = new SqlParameter("@Precio", SqlDbType.Decimal);
                    Precio.Value = paquete.Precio;
                    Precio.Direction = ParameterDirection.Input;

                    SqlParameter Comision = new SqlParameter("@Comision", SqlDbType.Decimal);
                    Comision.Value = paquete.Comision;
                    Comision.Direction = ParameterDirection.Input;

                    SqlParameter SoloCremacion = new SqlParameter("@SoloCremacion", SqlDbType.Bit);
                    SoloCremacion.Value = paquete.SoloCremacion;
                    SoloCremacion.Direction = ParameterDirection.Input;

                    SqlParameter retval = new SqlParameter(RET_VAL_PARAM_NAME, SqlDbType.Int);
                    retval.Direction = ParameterDirection.ReturnValue;

                    parametros = new SqlParameter[] {
                        idPaquete, Descripcion, Precio, Comision, SoloCremacion, retval
                    };
                    break;
            }

            return parametros;
        }

        protected override SqlParameter[] BuildParameters(IFilter IFilter, string strCommand)
        {
            SqlParameter[] parametros = null;
            switch (strCommand)
            {
                case "seleccionar_paquetes_servicio":
                    SqlParameter paramId = new SqlParameter("@id", SqlDbType.Int);
                    paramId.Direction = ParameterDirection.Input;
                    paramId.Value = ((PaqueteServicioFilter)IFilter).IdPaquete;

                    SqlParameter paramSoloCremacion = new SqlParameter("@soloCremacion", SqlDbType.Bit);
                    paramSoloCremacion.Direction = ParameterDirection.Input;
                    paramSoloCremacion.Value = ((PaqueteServicioFilter)IFilter).SoloCremacion;

                    parametros = new SqlParameter[]
                    {
                        paramId, paramSoloCremacion
                    };
                    break;
            }

            return parametros;
        }
    }
}
