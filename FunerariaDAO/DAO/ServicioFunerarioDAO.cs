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
    public class ServicioFunerarioDAO : IDao
    {
        protected override string SP_DELETE_STR { get { return string.Empty; } }
        protected override string SP_GETALL_STR { get { return "sp_select_ServiciosFunerarios"; } }
        protected override string SP_GETBYFILTER_STR { get { return "sp_select_ServiciosFunerarios"; } }
        protected override string SP_GETBYID_STR { get { return string.Empty; } }
        protected override string SP_SAVE_STR { get { return "guardar_servicioFunerario"; } }

        protected override IModel BuildModel(IDataReader dataReader)
        {
            ServicioFunerario servicioFunerario = new ServicioFunerario();

            servicioFunerario.ID = dataReader.GetInt32(dataReader.GetOrdinal("ID"));
            servicioFunerario.IdPaquete = dataReader.GetInt32(dataReader.GetOrdinal("IdPaquete"));
            servicioFunerario.IdAsesor = dataReader.GetInt32(dataReader.GetOrdinal("IdAsesor"));
            servicioFunerario.IdCliente = dataReader.GetInt32(dataReader.GetOrdinal("IdCliente"));
            servicioFunerario.IdDomicilioCobranza = dataReader.GetInt32(dataReader.GetOrdinal("IdDomicilioCobranza"));
            servicioFunerario.FechaSolicitud = dataReader.GetDateTime(dataReader.GetOrdinal("FechaSolicitud"));
            servicioFunerario.FechaContrato = dataReader.GetDateTime(dataReader.GetOrdinal("FechaContrato"));
            servicioFunerario.NumeroContrato = dataReader.GetString(dataReader.GetOrdinal("NumeroContrato"));
            servicioFunerario.NumeroSolicitud = dataReader.GetString(dataReader.GetOrdinal("NumeroSolicitud"));
            servicioFunerario.Costo = dataReader.GetDecimal(dataReader.GetOrdinal("Costo"));
            servicioFunerario.TitularSustituto = dataReader.GetString(dataReader.GetOrdinal("TitularSustituto"));
            servicioFunerario.IdFrecuenciaAbonos = dataReader.GetInt32(dataReader.GetOrdinal("IdFrecuenciaAbonos"));
            servicioFunerario.ServicioYaProporcionado = dataReader.GetBoolean(dataReader.GetOrdinal("ServicioYaProporcionado"));
            servicioFunerario.EstatusCobranza = (EstatusCobranzaServicioFunerario)dataReader.GetInt32(dataReader.GetOrdinal("EstatusCobranza"));

            return servicioFunerario;
        }

        protected override SqlParameter[] BuildParameters(IModel IFilter, string strCommand)
        {
            ServicioFunerario servicioFunerario = (ServicioFunerario)IFilter;
            SqlParameter[] parametros = null;

            switch (strCommand)
            {
                case "guardar_servicioFunerario":
                    SqlParameter id = new SqlParameter("@ID", SqlDbType.Int);
                    id.Value = servicioFunerario.ID;
                    id.Direction = ParameterDirection.Input;

                    SqlParameter IdPaquete = new SqlParameter("@IdPaquete", SqlDbType.Int);
                    IdPaquete.Value = servicioFunerario.IdPaquete;
                    IdPaquete.Direction = ParameterDirection.Input;

                    SqlParameter IdAsesor = new SqlParameter("@IdAsesor", SqlDbType.Int);
                    IdAsesor.Value = servicioFunerario.IdAsesor;
                    IdAsesor.Direction = ParameterDirection.Input;

                    SqlParameter IdCliente = new SqlParameter("@IdCliente", SqlDbType.Int);
                    IdCliente.Value = servicioFunerario.IdCliente;
                    IdCliente.Direction = ParameterDirection.Input;

                    SqlParameter IdDomicilioCobranza = new SqlParameter("@IdDomicilioCobranza", SqlDbType.Int);
                    IdDomicilioCobranza.Value = servicioFunerario.IdDomicilioCobranza;
                    IdDomicilioCobranza.Direction = ParameterDirection.Input;

                    SqlParameter FechaSolicitud = new SqlParameter("@FechaSolicitud", SqlDbType.DateTime);
                    FechaSolicitud.Value = servicioFunerario.FechaSolicitud;
                    FechaSolicitud.Direction = ParameterDirection.Input;

                    SqlParameter FechaContrato = new SqlParameter("@FechaContrato", SqlDbType.DateTime);
                    FechaContrato.Value = servicioFunerario.FechaContrato;
                    FechaContrato.Direction = ParameterDirection.Input;

                    SqlParameter NumeroSolicitud = new SqlParameter("@NumeroSolicitud", SqlDbType.VarChar);
                    NumeroSolicitud.Value = servicioFunerario.NumeroSolicitud;
                    NumeroSolicitud.Direction = ParameterDirection.Input;

                    SqlParameter NumeroContrato = new SqlParameter("@NumeroContrato", SqlDbType.VarChar);
                    NumeroContrato.Value = servicioFunerario.NumeroContrato;
                    NumeroContrato.Direction = ParameterDirection.Input;

                    SqlParameter Costo = new SqlParameter("@Costo", SqlDbType.Decimal);
                    Costo.Value = servicioFunerario.Costo;
                    Costo.Direction = ParameterDirection.Input;

                    SqlParameter TitularSustituto = new SqlParameter("@TitularSustituto", SqlDbType.VarChar);
                    if (servicioFunerario.TitularSustituto == null)
                        TitularSustituto.Value = DBNull.Value;
                    else
                        TitularSustituto.Value = servicioFunerario.TitularSustituto;
                    TitularSustituto.Direction = ParameterDirection.Input;

                    SqlParameter IdFrecuenciaAbonos = new SqlParameter("@IdFrecuenciaAbonos", SqlDbType.Int);
                    IdFrecuenciaAbonos.Value = servicioFunerario.IdFrecuenciaAbonos;
                    IdFrecuenciaAbonos.Direction = ParameterDirection.Input;

                    SqlParameter ServicioYaProporcionado = new SqlParameter("@ServicioYaProporcionado", SqlDbType.Bit);
                    ServicioYaProporcionado.Value = servicioFunerario.ServicioYaProporcionado;
                    ServicioYaProporcionado.Direction = ParameterDirection.Input;

                    SqlParameter IdEstatusCobranza = new SqlParameter("@IdEstatusCobranza", SqlDbType.Int);
                    IdEstatusCobranza.Value = (int)servicioFunerario.EstatusCobranza;
                    IdEstatusCobranza.Direction = ParameterDirection.Input;

                    SqlParameter retval = new SqlParameter(RET_VAL_PARAM_NAME, SqlDbType.Int);
                    retval.Direction = ParameterDirection.ReturnValue;

                    parametros = new SqlParameter[] {
                        id,
                        IdPaquete,
                        IdAsesor,
                        IdCliente,
                        IdDomicilioCobranza,
                        FechaSolicitud,
                        FechaContrato,
                        NumeroSolicitud,
                        NumeroContrato,
                        Costo,
                        TitularSustituto,
                        IdFrecuenciaAbonos,
                        ServicioYaProporcionado,
                        IdEstatusCobranza,
                        retval
                    };
                    break;
            }

            return parametros;
        }

        protected override SqlParameter[] BuildParameters(IFilter IFilter, string strCommand)
        {
            ServicioFunerario servicioFunerario = (ServicioFunerario)IFilter;

            SqlParameter[] parametros = null;
            switch (strCommand)
            {
                case "sp_select_ServiciosFunerarios":
                    SqlParameter id = new SqlParameter("@ID", SqlDbType.Int);
                    id.Value = servicioFunerario.ID;
                    id.Direction = ParameterDirection.Input;

                    SqlParameter IdPaquete = new SqlParameter("@IdPaquete", SqlDbType.Int);
                    IdPaquete.Value = servicioFunerario.IdPaquete;
                    IdPaquete.Direction = ParameterDirection.Input;

                    SqlParameter IdAsesor = new SqlParameter("@IdAsesor", SqlDbType.Int);
                    IdAsesor.Value = servicioFunerario.IdAsesor;
                    IdAsesor.Direction = ParameterDirection.Input;

                    SqlParameter IdCliente = new SqlParameter("@IdCliente", SqlDbType.Int);
                    IdCliente.Value = servicioFunerario.IdCliente;
                    IdCliente.Direction = ParameterDirection.Input;

                    SqlParameter IdDomicilioCobranza = new SqlParameter("@IdDomicilioCobranza", SqlDbType.Int);
                    IdDomicilioCobranza.Value = servicioFunerario.IdDomicilioCobranza;
                    IdDomicilioCobranza.Direction = ParameterDirection.Input;

                    SqlParameter NumeroSolicitud = new SqlParameter("@NumeroSolicitud", SqlDbType.VarChar);
                    NumeroSolicitud.Value = servicioFunerario.NumeroSolicitud;
                    NumeroSolicitud.Direction = ParameterDirection.Input;

                    SqlParameter NumeroContrato = new SqlParameter("@NumeroContrato", SqlDbType.VarChar);
                    NumeroContrato.Value = servicioFunerario.NumeroContrato;
                    NumeroContrato.Direction = ParameterDirection.Input;

                    SqlParameter IdFrecuenciaAbonos = new SqlParameter("@IdFrecuenciaAbonos", SqlDbType.Int);
                    IdFrecuenciaAbonos.Value = servicioFunerario.IdFrecuenciaAbonos;
                    IdFrecuenciaAbonos.Direction = ParameterDirection.Input;

                    SqlParameter ServicioYaProporcionado = new SqlParameter("@ServicioYaProporcionado", SqlDbType.Bit);
                    ServicioYaProporcionado.Value = servicioFunerario.ServicioYaProporcionado;
                    ServicioYaProporcionado.Direction = ParameterDirection.Input;

                    SqlParameter IdEstatusCobranza = new SqlParameter("@IdEstatusCobranza", SqlDbType.Int);
                    IdEstatusCobranza.Value = servicioFunerario.EstatusCobranza;
                    IdEstatusCobranza.Direction = ParameterDirection.Input;

                    parametros = new SqlParameter[] {
                        id,
                        IdPaquete,
                        IdAsesor,
                        IdCliente,
                        IdDomicilioCobranza,
                        NumeroSolicitud,
                        NumeroContrato,
                        IdFrecuenciaAbonos,
                        ServicioYaProporcionado,
                        IdEstatusCobranza
                    };
                    break;
            }

            return parametros;
        }
    }
}
