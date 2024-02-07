using MyApi.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAPI.Application.Service.Products.Query
{
    public interface IGetProductManagmentService
    {
        Task<ResultDto<List<GetProduct_Dto>>> GetProduct();
        Task<ResultDto<GetProduct_Dto>> GetProduct(long Id);
    }
}
