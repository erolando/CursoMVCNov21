using System.Data;
using System.Data.SqlClient;

namespace HomeDepot.DataLayer.Repositories
{
    public class BaseRepository
    {
        public SqlConnection SqlConnection()
        {
            return new SqlConnection("Server=LAPTOP-LA2FAGIE\\SQL2019;Database=CursoCotizaciones;Trusted_Connection=True;");
        }

        public IDbConnection CreateConnection()
        {
            var conn = SqlConnection();
            conn.Open();
            return conn;
        }
    }
}
