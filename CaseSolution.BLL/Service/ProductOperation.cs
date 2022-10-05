using CaseSolution.BLL.Interface;
using CaseSolution.DAL.Interface;
using CaseSolution.Models.Products;
using CaseSolution.Models.Request;
using MongoDB.Bson;
using System.Collections.Generic;

namespace CaseSolution.BLL.Service
{
    public class ProductOperation : IProductOperation
    {
        readonly IProductRepository _productRepository;
        public ProductOperation(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }
        public string AddProduct(ProductRequestModel model)
        {
            if (model is null)
                return "Product could not be added.";

            Product product = new Product()
            {
                Id = ObjectId.GenerateNewId(),
                ProductName = model.ProductName,
                ProductDescription = model.ProductDescription,
                Amount = model.Amount,
            };

            _productRepository.Add(product);

            return "Product has been added.";
        }

        public string DeleteProduct(ObjectId id)
        {
            var product = _productRepository.GetProductById(id);
            if (product is null)
                return "Product was not found.";

            _productRepository.Delete(id);
            return "Product has been deleted.";
        }

        public List<Product> GetAllProducts() => _productRepository.GetAllProducts();

        public Product GetProductById(string id)
        {
            var productId = new ObjectId(id);
            return _productRepository.GetProductById(productId);
        }
        public string UpdateProduct(UpdateProductRequestModel model)
        {
            var productId = new ObjectId(model.Id);
            var product = _productRepository.GetProductById(productId);
            if (product is null)
                return "Product was not found.";

            product.Id = productId;
            product.ProductName = model.ProductName;
            product.ProductDescription = model.ProductDescription;
            product.Amount = model.Amount;

            _productRepository.Update(product);
            return "Product has been updated";
        }
    }
}
