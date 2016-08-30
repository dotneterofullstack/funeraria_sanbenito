using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Funeraria.DAL.Enums;
using Funeraria.DAL.Models
;
namespace Funeraria.DAL.DAO
{
    public class TelefonosDAO: IDao
    {
        protected override string SP_DELETE_STR { get { return string.Empty; } }
        protected override string SP_GETALL_STR
        {
            get
            {
                string strSelect = string.Empty;
                switch (Propietario)
                {
                    case PropietarioEnum.Cliente:
                        strSelect = "seleccionar_telefonos_cliente";
                        break;
                    case PropietarioEnum.Asesor:
                        strSelect = "seleccionar_telefonos_asesor";
                        break;
                }

                return strSelect;
            }
        }
        protected override string SP_GETBYFILTER_STR { get {
                string strSelect = string.Empty;
                switch (Propietario)
                {
                    case PropietarioEnum.Cliente:
                        strSelect = "seleccionar_telefonos_cliente";
                        break;
                    case PropietarioEnum.Asesor:
                        strSelect = "seleccionar_telefonos_asesor";
                        break;
                }

                return strSelect;
            }
        }
        protected override string SP_GETBYID_STR { get { return string.Empty; } }
        protected override string SP_SAVE_STR { get {
                {
                    string strguardar = string.Empty;
                    switch (Propietario)
                    {
                        case PropietarioEnum.Cliente:
                            strguardar = "guardar_telefono_cliente";
                            break;
                        case PropietarioEnum.Asesor:
                            strguardar = "guardar_telefono_Asesor";
                            break;
                    }

                    return strguardar;
                };
            }
        }
        public PropietarioEnum Propietario { get; set; }

        protected override IModel BuildModel(IDataReader dataReader)
        {
            Telefono telefono = new Telefono();

            telefono.ID = dataReader.GetInt32(dataReader.GetOrdinal("ID"));
            telefono.IdTipoTelefono = dataReader.GetInt32(dataReader.GetOrdinal("IdTipoTelefono"));
            telefono.NoTelefono = dataReader.GetString(dataReader.GetOrdinal("Telefono"));
            telefono.Extension = dataReader.GetString(dataReader.GetOrdinal("Extension"));

            return telefono;
        }

        protected override SqlParameter[] BuildParameters(IModel IFilter, string strCommand)
        {
            SqlParameter[] parametros = null;
            Telefono telefono = (Telefono)IFilter;

            switch (strCommand)
            {
                case "guardar_telefono_cliente":
                case "guardar_telefono_Asesor":
                    SqlParameter idPropietario = null;
                    if (Propietario == PropietarioEnum.Cliente)
                        idPropietario = new SqlParameter("@idCliente", SqlDbType.Int);
                    else if (Propietario == PropietarioEnum.Asesor)
                        idPropietario = new SqlParameter("@idAsesor", SqlDbType.Int);

                    idPropietario.Direction = ParameterDirection.Input;
                    idPropietario.Value = telefono.IdPropietario;

                    SqlParameter tipoTelefono = new SqlParameter("@idTipoTelefono", SqlDbType.Int);
                    tipoTelefono.Direction = ParameterDirection.Input;
                    tipoTelefono.Value = telefono.IdTipoTelefono;

                    SqlParameter noTelefono = new SqlParameter("@telefono", SqlDbType.VarChar);
                    noTelefono.Direction = ParameterDirection.Input;
                    noTelefono.Value = telefono.NoTelefono;

                    SqlParameter extension = new SqlParameter("@extension", SqlDbType.VarChar);
                    extension.Direction = ParameterDirection.Input;
                    extension.Value = telefono.Extension;

                    SqlParameter retval = new SqlParameter(RET_VAL_PARAM_NAME, SqlDbType.Int);
                    retval.Direction = ParameterDirection.ReturnValue;

                    parametros = new SqlParameter[]
                    {
                        idPropietario, tipoTelefono, noTelefono, extension, retval
                    };
                    break;
               
            }

            return parametros;  
        }

        protected override SqlParameter[] BuildParameters(IFilter IFilter, string strCommand)
        {
            SqlParameter[] parametros = null;
            Propietario = ((TelefonoFilter)IFilter).TipoPropietario;

            switch (strCommand)
            {
                case "seleccionar_telefonos_cliente":
                case "seleccionar_telefonos_asesor":
                    SqlParameter idPropietario = null;
                    if (Propietario == PropietarioEnum.Cliente)
                        idPropietario = new SqlParameter("@idCliente", SqlDbType.Int);
                    else if (Propietario == PropietarioEnum.Asesor)
                        idPropietario = new SqlParameter("@idAsesor", SqlDbType.Int);

                    idPropietario.Value = ((TelefonoFilter)IFilter).IdPropietario;

                    parametros = new SqlParameter[]
                    {
                        idPropietario
                    };
                    break;
            }

            return parametros;
        }
    }
}
