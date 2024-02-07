using Microsoft.Extensions.Caching.Memory;
using MyAPI.Application.Interface.Context;
using MyAPI.Application.Interface.FaccadPatern;
using MyAPI.Application.Service.Customer.Command;
using MyAPI.Application.Service.Customer.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAPI.Application.Service.Customers.Facad
{
    public class CustomerFacadPatern : ICustomerFacadPatern
    {
        private readonly IDataBaseContext _context;
        public CustomerFacadPatern(IDataBaseContext context)
        {
            _context=context;
        }
        private ICustomerManagmentService? _CustomerManagmentService;
        public ICustomerManagmentService CustomerManagmentService
        {
            get
            {
                return _CustomerManagmentService = _CustomerManagmentService ?? new CustomerManagmentService(_context);
            }
        }
        private IGetCustomerManagmentService? _GetCustomerManagmentService;
        public IGetCustomerManagmentService GetCustomerManagmentService
        {
            get
            {
                return _GetCustomerManagmentService = _GetCustomerManagmentService ?? new GetCustomerManagmentService(_context);
            }
        }
    }
}
