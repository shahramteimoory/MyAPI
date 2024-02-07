using MyAPI.Application.Service.Customer.Command;
using MyAPI.Application.Service.Customer.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAPI.Application.Interface.FaccadPatern
{
    public interface ICustomerFacadPatern
    {
        ICustomerManagmentService CustomerManagmentService { get; }
        IGetCustomerManagmentService GetCustomerManagmentService { get;}
    }
}
