using Microsoft.AspNetCore.Mvc;
using MyAPI.Application.Interface.FaccadPatern;
using MyAPI.Application.Service.Products.Command;

namespace MyAPI.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductFacadPatern _productFacadPatern;
        public ProductController(IProductFacadPatern productFacadPatern)
        {
            _productFacadPatern= productFacadPatern;
        }
        [HttpGet]
        public async Task<IActionResult> GetProduct()
        {
            var result=await _productFacadPatern.GetProductManagmentService.GetProduct();
            if (result.IsSuccess)
            {
                Request.HttpContext.Response.Headers.Add("X-Count", result.Data.Count().ToString());
            }

            return Json(result);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetProduct(long Id)
        {
            var result=await _productFacadPatern.GetProductManagmentService.GetProduct(Id);
            return Json(result);
        }
        [HttpPost]
        public async Task<IActionResult> InsertProduct(InsertProduct_Dto req)
        {
            var result=await _productFacadPatern.ProductManagmentService.InsertProduct(req);
            return Json(result);
        }
        [HttpPut]
        public async Task<IActionResult> EditProduct(EditProduct_Dto req)
        {
            var result=await _productFacadPatern.ProductManagmentService.EditProduct(req);
            return Json(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(long Id)
        {
            var result=await _productFacadPatern.ProductManagmentService.DeleteProduct(Id);
            return Json(result);
        }
    }
}
