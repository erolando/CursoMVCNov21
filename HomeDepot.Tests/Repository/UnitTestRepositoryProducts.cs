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
            Repository = new RepositoryProducts();
        }
        [TestMethod]
        public void TestGetAll()
        {
            List<ModelProduct> results = Repository.GetAll();

            Assert.IsTrue(results.Count > 0);

            foreach (ModelProduct product in results)
            {
                Assert.IsTrue(product.Nombre.Length > 0);
                Assert.IsNotNull(product.IdCategoriaProducto);
                Assert.IsFalse(product.IdCategoriaProducto < 0);
            }
        }
    }
}
