using MyApi.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAPI.Application.Service.Products.Command
{
    public interface IProductManagmentService
    {
       Task<ResultDto> InsertProduct(InsertProduct_Dto req);
        Task<ResultDto> EditProduct(EditProduct_Dto req);
        Task<ResultDto> DeleteProduct(long id);
    }
}
