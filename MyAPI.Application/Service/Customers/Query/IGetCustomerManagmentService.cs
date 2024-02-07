using MyApi.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAPI.Application.Service.Customer.Query
{
    public interface IGetCustomerManagmentService
    {
       Task<ResultDto<List<GetCustomr_Dto>>> Get();
       Task<ResultDto<GetCustomr_Dto>> Get(long Id);
    }
}
