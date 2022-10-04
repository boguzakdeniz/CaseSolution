using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CaseSolution.Models.Products
{
    public class Product
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double Amount { get; set; }
    }
}
