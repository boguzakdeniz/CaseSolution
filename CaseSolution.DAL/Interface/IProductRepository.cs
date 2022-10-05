using CaseSolution.Models.Products;
using MongoDB.Bson;
using System.Collections.Generic;

namespace CaseSolution.DAL.Interface
{
    public interface IProductRepository
    {
        public List<Product> GetAllProducts();
        public Product GetProductById(ObjectId id);
        void Add(Product entity);
        void Update(Product entity);
        void Delete(ObjectId id);
    }
}
