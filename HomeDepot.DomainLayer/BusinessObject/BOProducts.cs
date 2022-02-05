using HomeDepot.DataLayer.Entities;
using HomeDepot.DataLayer.Repositories;
using HomeDepot.DomainLayer.Assemblies;
using HomeDepot.DomainLayer.DTO;
using HomeDepot.DomainLayer.RQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeDepot.DomainLayer.BusinessObject
{
    public class BOProducts
    {
        public readonly RepositoryProducts RepositorioProducts;

        public BOProducts(string connectionString)
        {
            RepositorioProducts = new RepositoryProducts(connectionString: connectionString);
        }

        public DTOProduct Insert(RQProduct request)
        {
            ModelProduct resultDB = RepositorioProducts.Add(new ModelProduct()
            {
                Nombre = request.Nombre,
                Descripcion = request.Descripcion,
                Imagen = request.Imagen,
                IdCategoriaProducto = request.IdCategoriaProducto,
                CodigoBarras = request.CodigoBarras
            });
            return AssemblyProduct.GetDTO(resultDB);
        }

        public List<DTOProduct> GetAll()
        {
            return AssemblyProduct.GetListDTO(RepositorioProducts.GetAll());
        }
    }
}
