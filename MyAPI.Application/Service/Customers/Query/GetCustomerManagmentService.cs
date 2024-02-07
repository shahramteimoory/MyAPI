using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using MyApi.Common;
using MyApi.Common.Dto;
using MyAPI.Application.Interface.Context;

namespace MyAPI.Application.Service.Customer.Query
{
    public class GetCustomerManagmentService : IGetCustomerManagmentService
    {
        private readonly IDataBaseContext _context;
        
        public GetCustomerManagmentService(IDataBaseContext context)
        {
            _context=context;
            
        }
        public async Task<ResultDto<List<GetCustomr_Dto>>> Get()
        {
            try
            {
                var customrt =await _context.Customers.Select(s=> new GetCustomr_Dto
                {
                    Id = s.Id,
                    Address = s.Address,
                    City = s.City,
                    Email = s.Email,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Ostan=s.Ostan,
                    Phone = s.Phone,
                    ZipCode=s.ZipCode,
                }).ToListAsync();
                if (!customrt.Any())
                {
                    return new ResultDto<List<GetCustomr_Dto>>
                    {
                        IsSuccess = false,
                        Message = Alert.Public.NotFound.GetDescription(),
                        StatusCode=System.Net.HttpStatusCode.NotFound
                    };
                }
                return new ResultDto<List<GetCustomr_Dto>>
                {
                    IsSuccess = true,
                    Message = Alert.Public.Success.GetDescription(),
                    Data = customrt,
                    StatusCode=System.Net.HttpStatusCode.OK
                };

            }
            catch (Exception)
            {
                return new ResultDto<List<GetCustomr_Dto>>
                {
                    IsSuccess = false,
                    Message = Alert.Public.ServerException.GetDescription(),
                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                };
               
            }
        }

        public async Task<ResultDto<GetCustomr_Dto>> Get(long Id)
        {
            try
            {

                //var customrt = _cache.Get<Domain.Entities.Customer>(Id);
                //if (customrt==null)
                //{
                   var customrt = await _context.Customers.FindAsync(Id);

                //}


                if (customrt == null)
                {
                    return new ResultDto<GetCustomr_Dto>
                    {
                        IsSuccess = false,
                        Message = Alert.Public.NotFound.GetDescription(),
                        StatusCode= System.Net.HttpStatusCode.NotFound
                    };
                }
                //var cacheOptions = new MemoryCacheEntryOptions()
                //    .SetSlidingExpiration(TimeSpan.FromSeconds(60));

                //_cache.Set(customrt.Id, customrt, cacheOptions);
                var result = new GetCustomr_Dto
                {
                    Address = customrt.Address,
                    City = customrt.City,
                    Email = customrt.Email,
                    FirstName = customrt.FirstName,
                    Id = customrt.Id,
                    LastName = customrt.LastName,
                    Ostan = customrt.Ostan,
                    Phone = customrt.Phone,
                    ZipCode = customrt.ZipCode,
                };
                return new ResultDto<GetCustomr_Dto>
                {
                    IsSuccess = true,
                    Data = result,
                    Message = Alert.Public.Success.GetDescription(),
                    StatusCode=System.Net.HttpStatusCode.OK
                };
            }
            catch (Exception)
            {

                return new ResultDto<GetCustomr_Dto>
                {
                    IsSuccess = false,
                    Message = Alert.Public.ServerException.GetDescription(),
                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                };
            }
        }
    }
}
