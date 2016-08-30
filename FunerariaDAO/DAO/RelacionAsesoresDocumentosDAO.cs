using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Funeraria.DAL.Models;

namespace Funeraria.DAL.DAO
{
    public class RelacionAsesoresDocumentosDAO : IDao
    {
        protected override string SP_DELETE_STR
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        protected override string SP_GETALL_STR
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        protected override string SP_GETBYFILTER_STR
        {
            get
            {
                return "seleccionar_documentos_asesor";
            }
        }

        protected override string SP_GETBYID_STR
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        protected override string SP_SAVE_STR
        {
            get
            {
                return "guardar_documento_Asesor";
            }
        }

        protected override IModel BuildModel(IDataReader dataReader)
        {
            RelacionAsesoresDocumentos relacion = new RelacionAsesoresDocumentos();

            relacion.ID = dataReader.GetInt32(dataReader.GetOrdinal("ID"         ));
            relacion.IdAsesor = dataReader.GetInt32(dataReader.GetOrdinal("IdAsesor"   ));
            relacion.IdDocumento = dataReader.GetInt32(dataReader.GetOrdinal("IdDocumento"));

            return relacion;
        }

        protected override SqlParameter[] BuildParameters(IModel IFilter, string strCommand)
        {
            RelacionAsesoresDocumentos relacion = (RelacionAsesoresDocumentos)IFilter;
            SqlParameter[] parameters = null;

            switch (strCommand)
            {
                case "guardar_documento_Asesor":
                    SqlParameter idAsesor = new SqlParameter("@idAsesor", SqlDbType.Int);
                    idAsesor.Direction = ParameterDirection.Input;
                    idAsesor.Value = relacion.IdAsesor;

                    SqlParameter idDocumento = new SqlParameter("@idDocumento", SqlDbType.Int);
                    idDocumento.Direction = ParameterDirection.Input;
                    idDocumento.Value = relacion.IdDocumento;

                    SqlParameter retval = new SqlParameter(RET_VAL_PARAM_NAME, SqlDbType.Int);
                    retval.Direction = ParameterDirection.ReturnValue;

                    parameters = new SqlParameter[] {
                        idAsesor, idDocumento, retval
                    };
                    break;
            }

            return parameters;
        }

        protected override SqlParameter[] BuildParameters(IFilter IFilter, string strCommand)
        {
            RelacionAsesoresDocumentosFilter relacion = (RelacionAsesoresDocumentosFilter)IFilter;
            SqlParameter[] parameters = null;

            switch (strCommand)
            {
                case "seleccionar_documentos_asesor":
                    SqlParameter idAsesor = new SqlParameter("@idAsesor", SqlDbType.Int);
                    idAsesor.Direction = ParameterDirection.Input;
                    idAsesor.Value = relacion.IdAsesor;

                    parameters = new SqlParameter[] {
                        idAsesor
                    };
                    break;
            }

            return parameters;
        }
    }
}
