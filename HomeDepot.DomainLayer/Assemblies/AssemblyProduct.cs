using HomeDepot.DataLayer.Entities;
using HomeDepot.DomainLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeDepot.DomainLayer.Assemblies
{
    public static class AssemblyProduct
    {
        public static DTOProduct GetDTO(ModelProduct model)
        {
            return new DTOProduct()
            {
                Nombre = model.Nombre,
                Descripcion = model.Descripcion,
                Imagen = model.Imagen,
                IdProducto = model.IdProducto,
                IdCategoriaProducto = model.IdCategoriaProducto,
                CodigoBarras = model.CodigoBarras
            };
        }

        public static List<DTOProduct> GetListDTO(List<ModelProduct> models)
        {
            return models.Select(model => new DTOProduct() {
                Nombre = model.Nombre,
                Descripcion = model.Descripcion,
                Imagen = model.Imagen,
                IdProducto = model.IdProducto,
                IdCategoriaProducto = model.IdCategoriaProducto,
                CodigoBarras = model.CodigoBarras
            }).ToList();
        }
    }
}
