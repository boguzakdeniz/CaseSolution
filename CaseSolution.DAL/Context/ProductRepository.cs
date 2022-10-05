using CaseSolution.DAL.Interface;
using CaseSolution.Models.Products;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;

namespace CaseSolution.DAL.Context
{
    public class ProductRepository : IProductRepository
    {
        IMongoCollection<Product> _collection;

        public ProductRepository()
        {
            _collection = new MongoClient("mongodb+srv://boguzakdeniz:y6yJ0L9fCJDjeHOo@productcluster.pjuthay.mongodb.net/ProductDB?retryWrites=true&w=majority").GetDatabase("ProductDB").GetCollection<Product>("Products");
        }
        public void Add(Product entity)
        {
            entity.Id = ObjectId.GenerateNewId();
            _collection.InsertOne(entity);
        }

        public void Delete(object id) => _collection.DeleteOne(x => x.Id == (ObjectId)id);

        public List<Product> GetAllProducts() => _collection.Find(_ => true).ToList();

        public Product GetProductById(ObjectId id) => _collection.Find(x => x.Id == id)?.FirstOrDefault();

        public void Update(Product entity) => _collection.ReplaceOne(x => x.Id == entity.Id, entity);


    }
}
