using CaseSolution.DAL.Interface;
using CaseSolution.Models.Products;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;

namespace CaseSolution.DAL.Context
{
    public class ProductRepository : IProductRepository
    {
        readonly IMongoCollection<Product> _collection;

        public ProductRepository(IConfiguration configuration)
        {
            _collection = new MongoClient(configuration["ConnectionStrings"]).GetDatabase("ProductDB").GetCollection<Product>("Products");
        }
        public void Add(Product entity)
        {
            entity.Id = ObjectId.GenerateNewId();
            _collection.InsertOne(entity);
        }

        public void Delete(ObjectId id) => _collection.DeleteOne(x => x.Id == id);

        public List<Product> GetAllProducts() => _collection.Find(_ => true).ToList();

        public Product GetProductById(ObjectId id) => _collection.Find(x => x.Id == id)?.FirstOrDefault();

        public void Update(Product entity) => _collection.ReplaceOne(x => x.Id == entity.Id, entity);


    }
}
