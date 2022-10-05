using CaseSolution.Models.Basket;

namespace CaseSolution.BLL.Interface
{
    public interface IBasketOperation
    {
        public Basket GetProductsInBasket();

        public string AddProductToBasket(ProductBasketModel model);

        public string DeleteProductByIdInBasket(string id);

        public string DeleteAllProductsInBasket();

    }
}
