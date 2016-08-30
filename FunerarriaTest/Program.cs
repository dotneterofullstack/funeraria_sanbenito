using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Funeraria.DAL.DAO;
using Funeraria.DAL.Models;

namespace FunerarriaTest
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = @"DESKTOP-6QJTG7S\SQLEXPRESS";
            builder.UserID = "sa";
            builder.Password = "w3d0123.";
            builder.InitialCatalog = "funeraria";

            EstadoDAO edodao = new EstadoDAO();
            edodao.SqlConString = builder.ConnectionString;
            edodao.GetAll();

            MunicipioDAO mpoDao = new MunicipioDAO();
            mpoDao.SqlConString = builder.ConnectionString;
            mpoDao.GetAll();

            mpoDao.GetByFilter(new MunicipioFilter() {
                IdEstado = 14
            });

            TipoTelefonoDAO tipoteldao = new TipoTelefonoDAO();
            tipoteldao.SqlConString = builder.ConnectionString;
            tipoteldao.GetAll();

            PaqueteServicioDAO paquetedao = new PaqueteServicioDAO();
            paquetedao.SqlConString = builder.ConnectionString;
            paquetedao.GetAll();

            FrecuenciaAbonoDAO frecuenciadao = new FrecuenciaAbonoDAO();
            frecuenciadao.SqlConString = builder.ConnectionString;
            frecuenciadao.GetAll();
        }
    }
}
