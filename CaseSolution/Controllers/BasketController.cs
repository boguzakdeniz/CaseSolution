﻿using CaseSolution.BLL.Interface;
using CaseSolution.Models.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaseSolution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : Controller
    {
        IBasketOperation _basketOperation;
        public BasketController(IBasketOperation basketOperation)
        {
            this._basketOperation = basketOperation;
        }
        [HttpGet]
        [Route("getProductsInBasket")]
        public JsonResult GetProductsInBasket() => Json(_basketOperation.GetProductsInBasket());

        [HttpPost]
        [Route("addProductToBasket")]
        public JsonResult AddProductToBasket(ProductRequestModel model) => Json(_basketOperation.AddProductToBasket(model));
      

        [HttpDelete]
        [Route("deleteProductByIdInBasket/{id}")]
        public JsonResult DeleteProductByIdInBasket(int id) => Json(_basketOperation.DeleteProductByIdInBasket(id));      

        [HttpDelete]
        [Route("deleteAllProductsInBasket")]
        public JsonResult DeleteAllProductsInBasket() => Json(_basketOperation.DeleteAllProductsInBasket());

    }
}
