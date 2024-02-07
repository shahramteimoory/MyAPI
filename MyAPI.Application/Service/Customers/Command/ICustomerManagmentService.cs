using MyApi.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAPI.Application.Service.Customer.Command
{
    public interface ICustomerManagmentService
    {
        Task<ResultDto> AddCustomer(AddCustomer_Dto req);
        Task<ResultDto> UpdateCustomer(UpdateCustomer_dto req);
        Task<ResultDto> DeleteCustomer(long id);
    }
}
