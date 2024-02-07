using ClientWebAplication.Models;
using ClientWebAplication.Repositoreis.CustomerRepositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ClientWebAplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ICustomerManagmentService _customerManagmentService;

        public HomeController(ILogger<HomeController> logger, ICustomerManagmentService customerManagmentService)
        {
            _logger = logger;
            _customerManagmentService= customerManagmentService;
        }

        public IActionResult Index()
        {
            
            return View(_customerManagmentService.GetAllCustomer());
        }
        public IActionResult EditCustomer(int Id)
        {
            var result = _customerManagmentService.GetCustomerById(Id);

            return View(result.Data);
            
        }
        [HttpPost]
        public IActionResult EditCustomer(UpdateCustomer_dto req)
        {
            var res= _customerManagmentService.UpdateCustomer(req);

            return RedirectToAction("Index");

        }
        public IActionResult AddCustomer()
        {
           
            return View();
        }
        [HttpPost]
        public IActionResult AddCustomer(AddCustomer_Dto req)
        {
            var result = _customerManagmentService.AddCustomer(req);
            if (!result.IsSuccess)
            {
                return View(result);
            }
            return RedirectToAction("Index");
        }
      
        public IActionResult DeleteCustomer(long id)
        {
            var result = _customerManagmentService.DeleteCustomer(id);
            return RedirectToAction("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
