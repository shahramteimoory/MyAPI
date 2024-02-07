using Microsoft.EntityFrameworkCore;
using MyApi.Common;
using MyApi.Common.Dto;
using MyAPI.Application.Interface.Context;

namespace MyAPI.Application.Service.Products.Query
{
    public class GetProductManagmentService : IGetProductManagmentService
    {
        private readonly IDataBaseContext _context;
        public GetProductManagmentService(IDataBaseContext context)
        {
            _context=context;
        }
        public async Task<ResultDto<List<GetProduct_Dto>>> GetProduct()
        {
            try
            {
                var product=await _context.Products.Select(s=>new GetProduct_Dto
                {
                    Id = s.Id,
                    Size = s.Size,
                    Status = s.Status,
                    Nooeh=s.Nooeh,
                    Price = s.Price,
                    ProductName = s.ProductName,
                }).ToListAsync();
                if (product.Count==0)
                {
                    return new ResultDto<List<GetProduct_Dto>>
                    {
                        IsSuccess = false,
                        Message = Alert.Public.NotFound.GetDescription(),
                    };
                }
                return new ResultDto<List<GetProduct_Dto>>
                {
                    IsSuccess = true,
                    Data = product,
                    Message = Alert.Public.Success.GetDescription(),
                };
            }
            catch (Exception)
            {

                return new ResultDto<List<GetProduct_Dto>>
                {
                    IsSuccess = false,
                    Message = Alert.Public.ServerException.GetDescription(),
                };
            }
        }

        public async Task<ResultDto<GetProduct_Dto>> GetProduct(long Id)
        {
            try
            {
                var product = await _context.Products.FindAsync(Id);
                if (product == null)
                {
                    return new ResultDto<GetProduct_Dto>
                    {
                        IsSuccess = false,
                        Message = Alert.Public.NotFound.GetDescription(),
                    };
                }
                var ExeProduct = new GetProduct_Dto()
                {
                    Id = product.Id,
                    Size = product.Size,
                    Status = product.Status,
                    Nooeh = product.Nooeh,
                    Price = product.Price,
                    ProductName = product.ProductName,
                };
                return new ResultDto<GetProduct_Dto> 
                {
                    IsSuccess = true,
                    Data = ExeProduct,
                    Message = Alert.Public.Success.GetDescription() 
                };
            }
            catch (Exception)
            {

                return new ResultDto<GetProduct_Dto>
                {
                    IsSuccess = false,
                    Message = Alert.Public.ServerException.GetDescription(),
                };
            }
        }
    }
}
