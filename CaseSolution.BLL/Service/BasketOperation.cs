using CaseSolution.BLL.Interface;
using CaseSolution.Models.Basket;
using CaseSolution.Models.Request;
using System;

namespace CaseSolution.BLL.Service
{
    public class BasketOperation : IBasketOperation
    {
        public string AddProductToBasket(ProductRequestModel model)
        {
            throw new NotImplementedException();
        }

        public string DeleteAllProductsInBasket()
        {
            throw new NotImplementedException();
        }

        public string DeleteProductByIdInBasket(int id)
        {
            throw new NotImplementedException();
        }

        public Basket GetProductsInBasket()
        {
            throw new NotImplementedException();
        }
    }
}
