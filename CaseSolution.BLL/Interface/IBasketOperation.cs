using CaseSolution.Models.Basket;
using CaseSolution.Models.Request;

namespace CaseSolution.BLL.Interface
{
    public interface IBasketOperation
    {
        public Basket GetProductsInBasket();

        public string AddProductToBasket(ProductRequestModel model);

        public string DeleteProductByIdInBasket(int id);

        public string DeleteAllProductsInBasket();

    }
}
