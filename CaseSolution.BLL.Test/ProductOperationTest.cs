using CaseSolution.BLL.Service;
using CaseSolution.DAL.Interface;
using CaseSolution.Models.Products;
using CaseSolution.Models.Request;
using MongoDB.Bson;
using Moq;
using NUnit.Framework;

namespace CaseSolution.BLL.Test
{
    public class ProductOperationTest
    {
        private Mock<IProductRepository> _productRepository;
        private ProductOperation _productOperation;

        [SetUp]
        public void Setup()
        {
            _productRepository = new Mock<IProductRepository>();
            _productOperation = new ProductOperation(_productRepository.Object);
        }
        [Test]
        public void AddProduct_NullParameter_CouldNotAddProduct()
        {
            ProductRequestModel product = null;

            var result = _productOperation.AddProduct(product);

            _productRepository.Verify(x => x.Add(It.IsAny<Product>()), Times.Never());

            Assert.AreEqual("Product could not be added.", result);
        }

        [Test]
        public void AddProduct_ThereIsParameter_AddProduct()
        {
            ProductRequestModel product = new ProductRequestModel() { ProductName = "Test" };

            _productRepository.Setup(x => x.Add(It.IsAny<Product>()));

            var result = _productOperation.AddProduct(product);

            _productRepository.Verify(x => x.Add(It.IsAny<Product>()), Times.Once());

            Assert.AreEqual("Product has been added.", result);
        }

        [Test]
        public void GetProductById_ThereIsParameter_GetProduct()
        {
            var objectId = ObjectId.GenerateNewId();
            _productRepository.Setup(x => x.GetProductById(objectId)).Returns(new Product());

            var result = _productOperation.GetProductById(objectId.ToString());

            _productRepository.Verify(x => x.GetProductById(objectId), Times.Once);

            Assert.IsNotNull(result);
        }
    }
}
