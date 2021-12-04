using HomeDepot.DataLayer.Entities;
using HomeDepot.DataLayer.Interfaces;
using System.Collections.Generic;
using Dapper;
using System.Data;
using System.Linq;

namespace HomeDepot.DataLayer.Repositories
{
    public class RepositoryProducts : BaseRepository, IRepository<ModelProduct>
    {
        public ModelProduct Add(ModelProduct entity)
        {
            using (var conn = CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Nombre", entity.Nombre);
                parameters.Add("@Imagen", entity.Imagen);
                parameters.Add("@IdCategoriaProducto", entity.IdCategoriaProducto);
                parameters.Add("@Descripcion", entity.Descripcion);
                parameters.Add("@CodigoBarras", entity.CodigoBarras);
                
                var results = conn.Query<ModelProduct>("dbo.SPIProducto",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);

                return results.AsList<ModelProduct>().FirstOrDefault();
            }
        }

        public ModelProduct Delete(ModelProduct entity)
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

        public ModelProduct update(ModelProduct entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
