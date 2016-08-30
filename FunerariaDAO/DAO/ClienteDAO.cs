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
    public class ClienteDAO : IDao
    {
        protected override string SP_DELETE_STR { get { return string.Empty; } }
        protected override string SP_GETALL_STR { get { return "seleccionar_clientes"; } }
        protected override string SP_GETBYFILTER_STR { get { return "seleccionar_clientes"; } }
        protected override string SP_GETBYID_STR { get { return string.Empty; } }
        protected override string SP_SAVE_STR { get { return "guardar_cliente"; } }

        public override int Save(IModel model, SqlTransaction trx)
        {
            int resultado = 0;

            try
            {
                Cliente cliente = (Cliente)model;
                int idCliente = base.Save(cliente, trx);

                DomiciliosDAO domDao = new DomiciliosDAO();
                domDao.Propietario = PropietarioEnum.Cliente;
                foreach (Domicilio domicilio in cliente.Domicilios)
                {
                    domicilio.IdPropietario = idCliente;
                    int idDomicilio = domDao.Save(domicilio, trx);
                }

                TelefonosDAO telDao = new TelefonosDAO();
                telDao.Propietario = PropietarioEnum.Cliente;
                foreach (Telefono telefono in cliente.Telefonos)
                {
                    telefono.IdPropietario = idCliente;
                    int idTelefono = telDao.Save(telefono, trx);
                }

                resultado = idCliente;
            }
            catch (Exception)
            {

                throw;
            }

            return resultado;
        }
        public override int Save(IModel model)
        {
            int resultado = 0;
            SqlConnection conn = null;
            SqlTransaction trx = null;

            try
            {
                Cliente cliente = (Cliente)model;
                conn = BuildConnection();
                conn.Open();
                trx = conn.BeginTransaction();

                int idCliente = base.Save(cliente, trx);

                DomiciliosDAO domDao = new DomiciliosDAO();
                domDao.Propietario = PropietarioEnum.Cliente;

                foreach (Domicilio domicilio in cliente.Domicilios)
                {
                    domicilio.IdPropietario = idCliente;
                    int idDomicilio = domDao.Save(domicilio, trx);
                }

                TelefonosDAO telDao = new TelefonosDAO();
                telDao.Propietario = PropietarioEnum.Cliente;
                foreach (Telefono telefono in cliente.Telefonos)
                {
                    telefono.IdPropietario = idCliente;
                    int idTelefono = telDao.Save(telefono, trx);
                }

                trx.Commit();
                resultado = idCliente;
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
            Cliente cliente = new Cliente();

            cliente.ID = dataReader.GetInt32(dataReader.GetOrdinal("ID"));
            cliente.Nombre = dataReader.GetString(dataReader.GetOrdinal("Nombre"));
            cliente.ApellidoPat = dataReader.GetString(dataReader.GetOrdinal("ApellidoPat"));
            cliente.ApellidoMat = dataReader.GetString(dataReader.GetOrdinal("ApellidoMat"));
            cliente.RFC = dataReader.GetString(dataReader.GetOrdinal("RFC"));

            return cliente;
        }

        protected override SqlParameter[] BuildParameters(IModel IFilter, string strCommand)
        {
            Cliente cliente = (Cliente)IFilter;
            SqlParameter[] parametros = null;

            switch (strCommand)
            {
                case "guardar_cliente":
                    SqlParameter idCliente = new SqlParameter("@id", SqlDbType.Int);
                    idCliente.Value = cliente.ID;
                    idCliente.Direction = ParameterDirection.Input;

                    SqlParameter nombre = new SqlParameter("@nombre", SqlDbType.VarChar);
                    nombre.Value = cliente.Nombre;
                    nombre.Direction = ParameterDirection.Input;

                    SqlParameter apellidoPat = new SqlParameter("@apellidoPat", SqlDbType.VarChar);
                    apellidoPat.Value = cliente.ApellidoPat;
                    apellidoPat.Direction = ParameterDirection.Input;

                    SqlParameter apellidoMat = new SqlParameter("@apellidoMat", SqlDbType.VarChar);
                    apellidoMat.Value = cliente.ApellidoMat;
                    apellidoMat.Direction = ParameterDirection.Input;

                    SqlParameter rfc = new SqlParameter("@rfc", SqlDbType.VarChar);
                    rfc.Value = cliente.RFC;
                    rfc.Direction = ParameterDirection.Input;

                    SqlParameter retval = new SqlParameter(RET_VAL_PARAM_NAME, SqlDbType.Int);
                    retval.Direction = ParameterDirection.ReturnValue;

                    parametros = new SqlParameter[] {
                        idCliente, nombre, apellidoPat, apellidoMat, rfc, retval
                    };
                    break;
            }

            return parametros;
        }

        protected override SqlParameter[] BuildParameters(IFilter IFilter, string strCommand)
        {
            ClienteFilter cliente = (ClienteFilter)IFilter;
            SqlParameter[] parametros = null;

            switch (strCommand)
            {
                case "seleccionar_clientes":
                    SqlParameter idCliente = new SqlParameter("@id", SqlDbType.Int);
                    idCliente.Value = cliente.ID;
                    idCliente.Direction = ParameterDirection.Input;

                    SqlParameter nombre = new SqlParameter("@nombre", SqlDbType.VarChar);
                    nombre.Value = cliente.Nombre;
                    nombre.Direction = ParameterDirection.Input;

                    SqlParameter apellidoPat = new SqlParameter("@apellidoPat", SqlDbType.VarChar);
                    apellidoPat.Value = cliente.ApellidoPat;
                    apellidoPat.Direction = ParameterDirection.Input;

                    SqlParameter apellidoMat = new SqlParameter("@apellidoMat", SqlDbType.VarChar);
                    apellidoMat.Value = cliente.ApellidoMat;
                    apellidoMat.Direction = ParameterDirection.Input;

                    SqlParameter rfc = new SqlParameter("@rfc", SqlDbType.VarChar);
                    rfc.Value = cliente.RFC;
                    rfc.Direction = ParameterDirection.Input;

                    parametros = new SqlParameter[] {
                        idCliente, nombre, apellidoPat, apellidoMat, rfc
                    };
                    break;
            }

            return parametros;
        }
    }
}
