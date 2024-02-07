using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAPI.Application.Interface.FaccadPatern;
using MyAPI.Application.Service.Customer.Command;

namespace MyAPI.api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerFacadPatern _customerFacadPatern;
        public CustomerController(ICustomerFacadPatern patern)
        {
            _customerFacadPatern = patern;
        }
        [HttpGet]
        //[ResponseCache(Duration = 60)]
        public async Task<IActionResult> GetCustomers()
        {
            
            var result = await _customerFacadPatern.GetCustomerManagmentService.Get();
            Response.StatusCode = (int)result.StatusCode;
                if (result.IsSuccess && result.Data != null)
                {
                    Request.HttpContext.Response.Headers.Add("X-Count", result.Data.Count().ToString());
                }
                return Json(result);

        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetCustomer(long Id)
        {
            var result = await _customerFacadPatern.GetCustomerManagmentService.Get(Id);
            Response.StatusCode = (int)result.StatusCode;
            return Json(result);
        }
        [HttpPost]
        public async Task<IActionResult> InsertCustomer([FromBody] AddCustomer_Dto req)
        {
            var result = await _customerFacadPatern.CustomerManagmentService.AddCustomer(req);
            Response.StatusCode = (int)result.StatusCode;
            return Json(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCustomer(UpdateCustomer_dto req)
        {
            var result = await _customerFacadPatern.CustomerManagmentService.UpdateCustomer(req);
            Response.StatusCode = (int)result.StatusCode;
            return Json(result);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult>RemoveCustomer(long Id)
        {
            var result =await _customerFacadPatern.CustomerManagmentService.DeleteCustomer(Id);
            Response.StatusCode = (int)result.StatusCode;
            return Json(result);
        } 
    }
}
