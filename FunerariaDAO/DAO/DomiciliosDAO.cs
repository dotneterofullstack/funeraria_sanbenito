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
    public class DomiciliosDAO : IDao
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
                        strSelect = "seleccionar_domicilios_cliente";
                        break;
                    case PropietarioEnum.Asesor:
                        strSelect = "seleccionar_domicilios_Asesor";
                        break;
                }

                return strSelect;
            }
        }
        protected override string SP_GETBYFILTER_STR
        {
            get
            {
                string strSelect = string.Empty;
                switch (Propietario)
                {
                    case PropietarioEnum.Cliente:
                        strSelect = "seleccionar_domicilios_cliente";
                        break;
                    case PropietarioEnum.Asesor:
                        strSelect = "seleccionar_domicilios_Asesor";
                        break;
                }

                return strSelect;
            }
        }
        protected override string SP_GETBYID_STR { get { return string.Empty; } }
        protected override string SP_SAVE_STR
        {
            get
            {
                {
                    string strguardar = string.Empty;
                    switch (Propietario)
                    {
                        case PropietarioEnum.Cliente:
                            strguardar = "guardar_domicilio_cliente";
                            break;
                        case PropietarioEnum.Asesor:
                            strguardar = "guardar_domicilio_Asesor";
                            break;
                    }

                    return strguardar;
                };
            }
        }

        public PropietarioEnum Propietario { get; set; }

        protected override IModel BuildModel(IDataReader dataReader)
        {
            Domicilio domicilio = new Domicilio();

            domicilio.ID = dataReader.GetInt32(dataReader.GetOrdinal("ID"                  ));
            domicilio.IdMunicipio = dataReader.GetInt32(dataReader.GetOrdinal("IdMunicipio"         ));
            domicilio.Calle = dataReader.GetString(dataReader.GetOrdinal("Calle"               ));
            domicilio.NumeroExterior = dataReader.GetString(dataReader.GetOrdinal("NumeroExterior"      ));
            domicilio.NumeroInterior = dataReader.GetString(dataReader.GetOrdinal("NumeroInterior"      ));
            domicilio.Colonia = dataReader.GetString(dataReader.GetOrdinal("Colonia"             ));
            domicilio.CodigoPostal = dataReader.GetString(dataReader.GetOrdinal("CodigoPostal"        ));
            domicilio.EntreCalles = dataReader.GetString(dataReader.GetOrdinal("EntreCalles"         ));
            domicilio.Latitud = dataReader.GetString(dataReader.GetOrdinal("Latitud"             ));
            domicilio.Longitud = dataReader.GetString(dataReader.GetOrdinal("Longitud"            ));

            return domicilio;
        }

        protected override SqlParameter[] BuildParameters(IModel IFilter, string strCommand)
        {
            SqlParameter[] parametros = null;
            Domicilio domicilio = (Domicilio)IFilter;

            switch (strCommand)
            {
                case "guardar_domicilio_cliente":
                case "guardar_domicilio_Asesor":
                    SqlParameter idPropietario = null;
                    if (Propietario == PropietarioEnum.Cliente)
                        idPropietario = new SqlParameter("@idCliente", SqlDbType.Int);
                    else if (Propietario == PropietarioEnum.Asesor)
                        idPropietario = new SqlParameter("@idAsesor", SqlDbType.Int);

                    idPropietario.Direction = ParameterDirection.Input;
                    idPropietario.Value = domicilio.IdPropietario;

                    SqlParameter idDomicilio = new SqlParameter("@idDomicilio", SqlDbType.Int);
                    idDomicilio.Direction = ParameterDirection.Input;
                    idDomicilio.Value = domicilio.ID;

                    SqlParameter idMunicipio = new SqlParameter("@idMunicipio", SqlDbType.Int);
                    idMunicipio.Direction = ParameterDirection.Input;
                    idMunicipio.Value = domicilio.IdMunicipio;

                    SqlParameter calle = new SqlParameter("@calle", SqlDbType.VarChar);
                    calle.Direction = ParameterDirection.Input;
                    calle.Value = domicilio.Calle;

                    SqlParameter numeroExterior = new SqlParameter("@numeroExterior", SqlDbType.VarChar);
                    numeroExterior.Direction = ParameterDirection.Input;
                    numeroExterior.Value = domicilio.NumeroExterior;

                    SqlParameter numeroInterior = new SqlParameter("@numeroInterior", SqlDbType.VarChar);
                    numeroInterior.Direction = ParameterDirection.Input;
                    numeroInterior.Value = domicilio.NumeroInterior;

                    SqlParameter colonia = new SqlParameter("@colonia", SqlDbType.VarChar);
                    colonia.Direction = ParameterDirection.Input;
                    colonia.Value = domicilio.Colonia;

                    SqlParameter codigoPostal = new SqlParameter("@codigoPostal", SqlDbType.VarChar);
                    codigoPostal.Direction = ParameterDirection.Input;
                    codigoPostal.Value = domicilio.CodigoPostal;

                    SqlParameter entreCalles = new SqlParameter("@entreCalles", SqlDbType.VarChar);
                    entreCalles.Direction = ParameterDirection.Input;
                    entreCalles.Value = domicilio.EntreCalles;

                    SqlParameter latitud = new SqlParameter("@latitud", SqlDbType.VarChar);
                    latitud.Direction = ParameterDirection.Input;
                    latitud.Value = domicilio.Latitud;

                    SqlParameter longitud = new SqlParameter("@longitud", SqlDbType.VarChar);
                    longitud.Direction = ParameterDirection.Input;
                    longitud.Value = domicilio.Longitud;

                    SqlParameter retval = new SqlParameter(RET_VAL_PARAM_NAME, SqlDbType.Int);
                    retval.Direction = ParameterDirection.ReturnValue;

                    parametros = new SqlParameter[]
                    {
                        idPropietario, idDomicilio, idMunicipio, calle, numeroExterior, numeroInterior, colonia, codigoPostal, entreCalles, latitud, longitud, retval
                    };
                    break;

            }

            return parametros;
        }

        protected override SqlParameter[] BuildParameters(IFilter IFilter, string strCommand)
        {
            SqlParameter[] parametros = null;
            Propietario = ((DomicilioFilter)IFilter).TipoPropietario;

            switch (strCommand)
            {
                case "seleccionar_domicilios_cliente":
                case "seleccionar_domicilios_Asesor":
                    SqlParameter idPropietario = null;
                    if (Propietario == PropietarioEnum.Cliente)
                        idPropietario = new SqlParameter("@idCliente", SqlDbType.Int);
                    else if (Propietario == PropietarioEnum.Asesor)
                        idPropietario = new SqlParameter("@idAsesor", SqlDbType.Int);

                    idPropietario.Value = ((DomicilioFilter)IFilter).IdPropietario;

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
