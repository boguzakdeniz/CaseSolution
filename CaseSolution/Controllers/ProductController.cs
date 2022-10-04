using CaseSolution.BLL.Interface;
using CaseSolution.Models.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;

namespace CaseSolution.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        IProductOperation _productOperation;
        public ProductController(IProductOperation productOperation)
        {
            this._productOperation = productOperation;
        }
        
        [HttpGet]
        [Route("getProduct/{id}")]
        public JsonResult GetProductById(string id) => Json(_productOperation.GetProductById(id));

        [HttpGet]
        [Route("getAllProducts")]
        public JsonResult GetAllProducts() => Json(_productOperation.GetAllProducts());

        [HttpPost]
        [Route("addProduct")]
        public JsonResult AddProduct(ProductRequestModel model) => Json(_productOperation.AddProduct(model));

        [HttpPost]
        [Route("updateProduct")]
        public JsonResult UpdateProduct(UpdateProductRequestModel model)
        {
            return Json(_productOperation.UpdateProduct(model));

        } //=> Json(_productOperation.UpdateProduct(model));

        [HttpDelete]
        [Route("deleteProduct")]
        public JsonResult DeleteProduct(string id)
        {
            var objectId = new ObjectId(id);
            return Json(_productOperation.DeleteProduct(objectId));
        }

    }

}
