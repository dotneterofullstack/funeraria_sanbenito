using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Funeraria.DAL.Models;
using Funeraria.DAL.Enums;

namespace Funeraria.DAL.DAO
{
    public class AsesorDAO : IDao
    {
        protected override string SP_DELETE_STR { get { return string.Empty; } }
        protected override string SP_GETALL_STR { get { return "seleccionar_Asesores"; } }
        protected override string SP_GETBYFILTER_STR { get { return "seleccionar_Asesores"; } }
        protected override string SP_GETBYID_STR { get { return string.Empty; } }
        protected override string SP_SAVE_STR { get { return "guardar_asesor"; } }

        public override int Save(IModel model)
        {
            int resultado = 0;
            SqlConnection conn = null;
            SqlTransaction trx = null;

            try
            {
                Asesor asesor = (Asesor)model;
                conn = BuildConnection();
                conn.Open();
                trx = conn.BeginTransaction();

                int idAsesor = base.Save(asesor, trx);

                DomiciliosDAO domDao = new DomiciliosDAO();
                domDao.Propietario = PropietarioEnum.Asesor;

                foreach (Domicilio domicilio in asesor.Domicilios)
                {
                    domicilio.IdPropietario = idAsesor;
                    int idDomicilio = domDao.Save(domicilio, trx);
                }

                TelefonosDAO telDao = new TelefonosDAO();
                telDao.Propietario = PropietarioEnum.Asesor;
                foreach (Telefono telefono in asesor.Telefonos)
                {
                    telefono.IdPropietario = idAsesor;
                    int idTelefono = telDao.Save(telefono, trx);
                }

                RelacionAsesoresDocumentosDAO relDao = new RelacionAsesoresDocumentosDAO();
                foreach (RelacionAsesoresDocumentos rel in asesor.RelacionAsesoresDocumentos)
                {
                    rel.IdAsesor = idAsesor;
                    int idRelacion = relDao.Save(rel, trx);
                }

                trx.Commit();
                resultado = idAsesor;
            }
            catch (Exception)
            {
                if (trx != null)
                    trx.Rollback();
                throw;
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }

            return resultado;
        }

        protected override IModel BuildModel(IDataReader dataReader)
        {
            Asesor asesor = new Asesor();

            asesor.ID = dataReader.GetInt32(dataReader.GetOrdinal("ID"));
            asesor.IdCargo = dataReader.GetInt32(dataReader.GetOrdinal("IdCargo"));
            asesor.IdAsesorInvita = dataReader.GetInt32(dataReader.GetOrdinal("IdAsesorInvita"));
            asesor.Codigo = dataReader.GetString(dataReader.GetOrdinal("Codigo"));
            asesor.Nombre = dataReader.GetString(dataReader.GetOrdinal("Nombre"));
            asesor.ApellidoPat = dataReader.GetString(dataReader.GetOrdinal("ApellidoPat"));
            asesor.ApellidoMat = dataReader.GetString(dataReader.GetOrdinal("ApellidoMat"));
            asesor.RFC = dataReader.GetString(dataReader.GetOrdinal("RFC"));

            return asesor;
        }

        protected override SqlParameter[] BuildParameters(IModel IFilter, string strCommand)
        {
            Asesor asesor = (Asesor)IFilter;
            SqlParameter[] parametros = null;

            switch (strCommand)
            {
                case "guardar_asesor":
                    SqlParameter idAsesor = new SqlParameter("@id", SqlDbType.Int);
                    idAsesor.Value = asesor.ID;
                    idAsesor.Direction = ParameterDirection.Input;

                    SqlParameter idCargo = new SqlParameter("@Cargo", SqlDbType.Int);
                    idCargo.Value = asesor.IdCargo;
                    idCargo.Direction = ParameterDirection.Input;

                    SqlParameter idAsesorInvita = new SqlParameter("@AsesorInvita", SqlDbType.Int);
                    idAsesorInvita.Direction = ParameterDirection.Input;
                    if (asesor.IdAsesorInvita == 0)
                    {
                        idAsesorInvita.Value = DBNull.Value;
                    }
                    else
                    {
                        idAsesorInvita.Value = asesor.IdAsesorInvita;
                    }

                    SqlParameter codigo = new SqlParameter("@codigo", SqlDbType.VarChar);
                    codigo.Value = asesor.Codigo;
                    codigo.Direction = ParameterDirection.Input;

                    SqlParameter nombre = new SqlParameter("@nombre", SqlDbType.VarChar);
                    nombre.Value = asesor.Nombre;
                    nombre.Direction = ParameterDirection.Input;

                    SqlParameter apellidoPat = new SqlParameter("@apellidoPat", SqlDbType.VarChar);
                    apellidoPat.Value = asesor.ApellidoPat;
                    apellidoPat.Direction = ParameterDirection.Input;

                    SqlParameter apellidoMat = new SqlParameter("@apellidoMat", SqlDbType.VarChar);
                    apellidoMat.Value = asesor.ApellidoMat;
                    apellidoMat.Direction = ParameterDirection.Input;

                    SqlParameter rfc = new SqlParameter("@rfc", SqlDbType.VarChar);
                    rfc.Value = asesor.RFC;
                    rfc.Direction = ParameterDirection.Input;

                    SqlParameter retval = new SqlParameter(RET_VAL_PARAM_NAME, SqlDbType.Int);
                    retval.Direction = ParameterDirection.ReturnValue;

                    parametros = new SqlParameter[] {
                        idAsesor, idCargo, idAsesorInvita, codigo, nombre, apellidoPat, apellidoMat, rfc, retval
                    };
                    break;
            }

            return parametros;
        }

        protected override SqlParameter[] BuildParameters(IFilter IFilter, string strCommand)
        {
            AsesorFilter asesor = (AsesorFilter)IFilter;
            SqlParameter[] parametros = null;

            switch (strCommand)
            {
                case "seleccionar_Asesores":
                    SqlParameter idAsesor = new SqlParameter("@id", SqlDbType.Int);
                    idAsesor.Value = asesor.ID;
                    idAsesor.Direction = ParameterDirection.Input;

                    SqlParameter idCargo = new SqlParameter("@Cargo", SqlDbType.Int);
                    idCargo.Value = asesor.IdCargo;
                    idCargo.Direction = ParameterDirection.Input;

                    SqlParameter idAsesorInvita = new SqlParameter("@AsesorInvita", SqlDbType.Int);
                    idAsesorInvita.Direction = ParameterDirection.Input;    
                    idAsesorInvita.Value = asesor.IdAsesorInvita;

                    SqlParameter codigo = new SqlParameter("@codigo", SqlDbType.VarChar);
                    codigo.Value = asesor.Codigo;
                    codigo.Direction = ParameterDirection.Input;

                    SqlParameter nombre = new SqlParameter("@nombre", SqlDbType.VarChar);
                    nombre.Value = asesor.Nombre;
                    nombre.Direction = ParameterDirection.Input;

                    SqlParameter apellidoPat = new SqlParameter("@apellidoPat", SqlDbType.VarChar);
                    apellidoPat.Value = asesor.ApellidoPat;
                    apellidoPat.Direction = ParameterDirection.Input;

                    SqlParameter apellidoMat = new SqlParameter("@apellidoMat", SqlDbType.VarChar);
                    apellidoMat.Value = asesor.ApellidoMat;
                    apellidoMat.Direction = ParameterDirection.Input;

                    SqlParameter rfc = new SqlParameter("@rfc", SqlDbType.VarChar);
                    rfc.Value = asesor.RFC;
                    rfc.Direction = ParameterDirection.Input;

                    SqlParameter retval = new SqlParameter(RET_VAL_PARAM_NAME, SqlDbType.Int);
                    retval.Direction = ParameterDirection.ReturnValue;

                    parametros = new SqlParameter[] {
                        idAsesor, idCargo, idAsesorInvita, codigo, nombre, apellidoPat, apellidoMat, rfc, retval
                    };
                    break;
            }

            return parametros;
        }
    }
}
