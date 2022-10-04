using CaseSolution.Models.Products;
using CaseSolution.Models.Request;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseSolution.BLL.Interface
{
    public interface IProductOperation
    {
        public Product GetProductById(string id);

        public List<Product> GetAllProducts();

        public string AddProduct(ProductRequestModel model);

        public string UpdateProduct(UpdateProductRequestModel model);

        public string DeleteProduct(ObjectId id);
    }
}
