using CaseSolution.BLL.Interface;
using CaseSolution.Models.Basket;
using System;
using System.Collections.Generic;

namespace CaseSolution.BLL.Service
{
    public class BasketOperation : IBasketOperation
    {
        ICacheOperation _cacheOperation;
        public readonly string RedisKey = "BASKET";
        public BasketOperation(ICacheOperation cacheOperation)
        {
            _cacheOperation = cacheOperation;
        }

        public string AddProductToBasket(ProductBasketModel model)
        {
            model.ProductId = Guid.NewGuid().ToString();

            var basket = GetProductsInBasket();
            basket.ProductList.Add(model);

            _cacheOperation.Set(RedisKey, basket);
            return "Product added to Basket.";
        }

        public string DeleteAllProductsInBasket()
        {
            _cacheOperation.Clear(RedisKey);
            return "Basket cleread.";
        }

        public string DeleteProductByIdInBasket(string id)
        {
            var basket = GetProductsInBasket();
            var deletedProduct = basket.ProductList.Find(x => x.ProductId == id);
            basket.ProductList.Remove(deletedProduct);

            _cacheOperation.Set(RedisKey, basket);
            return "Product has been removed from the basket.";
        }

        public Basket GetProductsInBasket()
        {
            var basket = _cacheOperation.Get<Basket>(RedisKey);

            if (basket is null)
            {
                basket = new Basket();
                basket.Id = 1;
                basket.ProductList = new List<ProductBasketModel>()
                {
                    new ProductBasketModel(){ProductId=Guid.NewGuid().ToString(),ProductName = "Dummy",ProductDescription = "Dummy",Amount=5000,Quantity=3}
                };
                _cacheOperation.Set(RedisKey, basket);
            }

            return basket;
        }
    }
}
