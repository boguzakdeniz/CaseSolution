using CaseSolution.Models.Products;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseSolution.DAL.Interface
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        public List<Product> GetAllProducts();
        public Product GetProductById(ObjectId id);
    }
}
