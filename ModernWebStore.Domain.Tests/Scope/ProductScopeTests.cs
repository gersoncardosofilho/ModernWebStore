using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModerWebStore.Domain.Entities;
using ModerWebStore.Domain.Scopes;

namespace ModernWebStore.Domain.Tests.Scope
{
    /// <summary>
    /// Summary description for ProductScopeTests
    /// </summary>
    [TestClass]
    public class ProductScopeTests
    {
        Product _validProduct = new Product("Placa Mãe", "Asus X900", 650.00m, 10, 1);
        Product _invalidProductTitle = new Product("", "Asus X900", 650.00m, 10, 1);
        Product _invalidProductDescription = new Product("Placa Mãe", "", 650.00m, 10, 1);
        Product _invalidProductPrice = new Product("Placa Mãe", "Asus X900", 0, 10, 1);
        Product _invalidProductQuantity = new Product("Placa Mãe", "Asus X900", 650.00m, 0, 1);
        Product _invalidProductCategory = new Product("Placa Mãe", "Asus X900", 650.00m, 10, 0);

        [TestMethod]
        [TestCategory("Product")]
        public void ShouldRegisterProduct()
        {
            Assert.AreEqual(true, ProductScopes.RegisterProductScopeIsValid(_validProduct));
        }

        [TestMethod]
        [TestCategory("Product")]
        public void ProductWithNoTitle()
        {
            Assert.AreEqual(false, ProductScopes.RegisterProductScopeIsValid(_invalidProductTitle));
        }

        [TestMethod]
        [TestCategory("Product")]
        public void ProductWithNoDescription()
        {
            Assert.AreEqual(false, ProductScopes.RegisterProductScopeIsValid(_invalidProductDescription));
        }

        [TestMethod]
        [TestCategory("Product")]
        public void ProductWithNoPrice()
        {
            Assert.AreEqual(false, ProductScopes.RegisterProductScopeIsValid(_invalidProductPrice));
        }

        [TestMethod]
        [TestCategory("Product")]
        public void ProductWithNoQuantity()
        {
            Assert.AreEqual(false, ProductScopes.RegisterProductScopeIsValid(_invalidProductQuantity));
        }

        [TestMethod]
        [TestCategory("Product")]
        public void ProductWithNoCategory()
        {
            Assert.AreEqual(false, ProductScopes.RegisterProductScopeIsValid(_invalidProductCategory));
        }
    }
}
