using System.Collections.Generic;
namespace CaseSolution.Models.Basket
{
    public class Basket
    {
        public int Id { get; set; }
        public List<ProductBasketModel> ProductList { get; set; }
    }
}
