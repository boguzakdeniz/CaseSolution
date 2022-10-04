using CaseSolution.BLL.Interface;
using CaseSolution.DAL.Interface;
using CaseSolution.Models.Products;
using CaseSolution.Models.Request;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseSolution.BLL.Service
{
    public class ProductOperation : IProductOperation
    {
        IProductRepository _productRepository;
        public ProductOperation(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }
        public string AddProduct(ProductRequestModel model)
        {
            if (model is null)
                return "Ürün eklenemedi";

            Product product = new Product()
            {
                Id = ObjectId.GenerateNewId(),
                ProductName = model.ProductName,
                ProductDescription = model.ProductDescription,
                Amount = model.Amount,
            };

            _productRepository.Add(product);

            return "Ürün veritabanına eklendi.";
        }

        public string DeleteProduct(ObjectId id)
        {
            var product = _productRepository.GetProductById(id);
            if (product is null)
                return "Ürün bulunamadı.";

            _productRepository.Delete(id);
            return "Ürün veritabanından silindi.";
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
                return "Ürün bulunamadı.";

            product.Id = productId;
            product.ProductName = model.ProductName;
            product.ProductDescription = model.ProductDescription;
            product.Amount = model.Amount;

            _productRepository.Update(product);
            return "Ürün güncellendi.";
        }
    }
}
