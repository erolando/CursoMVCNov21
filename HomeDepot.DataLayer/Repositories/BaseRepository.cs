﻿using System.Data;
using System.Data.SqlClient;

namespace HomeDepot.DataLayer.Repositories
{
    public class BaseRepository
    {
        public string ConnectionString { get; private set; }
        public BaseRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }
        public SqlConnection SqlConnection()
        {
            //#if DEBUG
            //            string connString = "BDDev,ip=1.0.1.199";
            //#else
            //            string connString = "DBProducccio197";
            //#endif
            return new SqlConnection(ConnectionString); 
            //"Server=LAPTOP-LA2FAGIE\\SQL2019;Database=CursoCotizaciones;Trusted_Connection=True;");
        }

        public IDbConnection CreateConnection()
        {
            var conn = SqlConnection();
            conn.Open();
            return conn;
        }
    }
}
