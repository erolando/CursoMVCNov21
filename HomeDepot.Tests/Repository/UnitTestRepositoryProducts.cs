using HomeDepot.DataLayer.Entities;
using HomeDepot.DataLayer.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace HomeDepot.Tests.Repository
{
    [TestClass]
    public class UnitTestRepositoryProducts
    {
        private readonly RepositoryProducts Repository;
        public UnitTestRepositoryProducts()
        {
            Repository = new RepositoryProducts(Constants.ConnStringDev);
        }
        [TestMethod]
        public void TestGetAll()
        {
            List<ModelProduct> results = Repository.GetAll();

            Assert.IsTrue(results.Count > 0);

            foreach (ModelProduct product in results)
            {
                ValidateModel(product);
            }
        }

        [TestMethod]
        public void TestInsert()
        {
            ModelProduct newProduct = new ModelProduct()
            {
                Nombre = "Prueba " + DateTime.Now.ToString(),
                Descripcion = $"Prueba {DateTime.Now}",
                IdCategoriaProducto = 1,
                CodigoBarras = Guid.NewGuid().ToString(),
                Imagen = new byte[0]
            };
            ModelProduct product = Repository.Add(newProduct);

            ValidateModel(product);
        }

        private static void ValidateModel(ModelProduct product)
        {
            Assert.IsNotNull(product);
            Assert.IsTrue(product.Nombre.Length > 0);
            Assert.IsTrue(product.Descripcion.Length > 0);
            Assert.IsNotNull(product.IdCategoriaProducto);
            Assert.IsFalse(product.IdCategoriaProducto < 0);
        }
    }
}
