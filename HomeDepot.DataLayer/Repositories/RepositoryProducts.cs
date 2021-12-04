using HomeDepot.DataLayer.Entities;
using HomeDepot.DataLayer.Interfaces;
using System.Collections.Generic;
using Dapper;
using System.Data;

namespace HomeDepot.DataLayer.Repositories
{
    public class RepositoryProducts : BaseRepository, IRepository<ModelProduct>
    {
        public void Add(ModelProduct entity)
        {
            /*
            
            
            Modificacion desde github web
            
            */
            Console.WriteLine("Prueba");
        }

        public void Delete(ModelProduct entity)
        {
            throw new System.NotImplementedException();
        }

        public ModelProduct Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<ModelProduct> GetAll()
        {
            using (var conn = CreateConnection())
            {
                var results = conn.Query<ModelProduct>("dbo.SPSProducto",
                    commandType: CommandType.StoredProcedure);

                return results.AsList<ModelProduct>();
            }                
        }

        public void update(ModelProduct entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
