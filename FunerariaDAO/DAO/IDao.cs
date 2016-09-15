using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Funeraria.DAL.Models;
using Newtonsoft.Json;

namespace Funeraria.DAL.DAO
{
    public abstract class IDao
    {
        private SqlConnection conn;
        protected abstract string SP_GETALL_STR { get; }
        protected abstract string SP_GETBYID_STR { get; }
        protected abstract string SP_GETBYFILTER_STR { get; }
        protected abstract string SP_SAVE_STR { get; }
        protected abstract string SP_DELETE_STR { get; }

        protected const string RET_VAL_PARAM_NAME = "@retval";

        public string SqlConString { get; set; }

        public virtual string GetJsonByFilter(IFilter filter)
        {
            string jsonString = string.Empty;
            List<IModel> todos = null;
            SqlCommand cmd = BuildCommand(SP_GETBYFILTER_STR);
            SqlParameter[] parametros = BuildParameters(filter, SP_GETBYFILTER_STR);
            cmd.Parameters.AddRange(parametros);

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                todos = new List<IModel>();
                jsonString = JsonConvert.SerializeObject(dt);
                dr.Close();
            }
            catch (Exception)
            {
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

            return jsonString;
        }
        public virtual IEnumerable<IModel> GetByFilter(IFilter filter)
        {
            List<IModel> todos = null;
            SqlCommand cmd = BuildCommand(SP_GETBYFILTER_STR);
            SqlParameter[] parametros = BuildParameters(filter, SP_GETBYFILTER_STR);
            cmd.Parameters.AddRange(parametros);

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                todos = new List<IModel>();
                while (dr.Read())
                {
                    IModel modelo = BuildModel(dr);
                    todos.Add(modelo);
                }
                dr.Close();
            }
            catch (Exception)
            {
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

            return todos;
        }

        public virtual int Save(IModel model, SqlTransaction transaccion)
        {
            SqlCommand cmd = BuildCommand(SP_SAVE_STR, transaccion);
            SqlParameter[] parametros = BuildParameters(model, SP_SAVE_STR);
            cmd.Parameters.AddRange(parametros);
            SqlParameter retval = cmd.Parameters[RET_VAL_PARAM_NAME];
            int resultado = 0;

            try
            {
                cmd.ExecuteNonQuery();
                resultado = int.Parse(retval.Value.ToString());
            }
            catch (Exception e)
            {
                throw;
            }

            return resultado;
        }
        public virtual int Save(IModel model)
        {
            SqlCommand cmd = BuildCommand(SP_SAVE_STR);
            SqlParameter[] parametros = BuildParameters(model, SP_SAVE_STR);
            cmd.Parameters.AddRange(parametros);
            SqlParameter retval = cmd.Parameters[RET_VAL_PARAM_NAME];
            int resultado = 0;

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                resultado = int.Parse(retval.Value.ToString());
            }
            catch (Exception e)
            {
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

        public virtual IEnumerable<IModel> GetAll()
        {
            List<IModel> todos = null;
            SqlCommand cmd = BuildCommand(SP_GETALL_STR);
            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                todos = new List<IModel>();
                while (dr.Read())
                {
                    IModel modelo = BuildModel(dr);
                    todos.Add(modelo);
                }
                dr.Close();
            }
            catch (Exception)
            {
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

            return todos; 
        }

        protected SqlConnection BuildConnection() {
            return new SqlConnection(SqlConString);
        }
        private SqlCommand BuildCommand(string strCommand, SqlTransaction transaccion = null)
        {
            SqlCommand cmd = new SqlCommand();
            if (transaccion == null)
            {
                conn = BuildConnection();
                cmd.CommandText = strCommand;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
            }
            else
            {
                cmd.CommandText = strCommand;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = transaccion.Connection;
                cmd.Transaction = transaccion;
            }

            return cmd;
        } 

        protected abstract IModel BuildModel(IDataReader dataReader);

        protected abstract SqlParameter[] BuildParameters(IFilter IFilter, string strCommand);

        protected abstract SqlParameter[] BuildParameters(IModel IFilter, string strCommand);
    }
}
