using MongoDB.Bson;

namespace CaseSolution.Models.Request
{
    public class UpdateProductRequestModel : ProductRequestModel
    {
        public string Id { get; set; }
    }
}
