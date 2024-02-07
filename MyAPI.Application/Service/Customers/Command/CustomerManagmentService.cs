using MyApi.Common;
using MyApi.Common.Dto;
using MyAPI.Application.Interface.Context;

namespace MyAPI.Application.Service.Customer.Command
{
    public class CustomerManagmentService : ICustomerManagmentService
    {
        private readonly IDataBaseContext _context;
        public CustomerManagmentService(IDataBaseContext context)
        {
            _context=context;
        }
        public async Task<ResultDto> AddCustomer(AddCustomer_Dto req)
        {
            try
            {
                Domain.Entities.Customer customer = new Domain.Entities.Customer();
                customer.Address = req.Address;
                customer.City = req.City;
                customer.Ostan=req.Ostan;
                customer.Email=req.Email;
                customer.LastName=req.LastName;
                customer.FirstName=req.FirstName;
                customer.ZipCode=req.ZipCode;
                customer.Phone=req.Phone;
                await _context.Customers.AddAsync(customer);
                await _context.SaveChangesAsync();
                return new ResultDto()
                {
                    IsSuccess = true,
                    Message = Alert.GetAddAlert(Alert.Entity.customer),
                    StatusCode=System.Net.HttpStatusCode.Created
                };
            }
            catch (Exception)
            {

                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = Alert.Public.ServerException.GetDescription(),
                    StatusCode=System.Net.HttpStatusCode.InternalServerError
                };
            }
        }

        public async Task<ResultDto> DeleteCustomer(long id)
        {
            try
            {
                var customer =await _context.Customers.FindAsync(id);
                if (customer==null)
                {
                    return new ResultDto
                    {
                        IsSuccess = false,
                        Message = Alert.Public.NotFound.GetDescription(),
                        StatusCode = System.Net.HttpStatusCode.NotFound
                    };
                }
                customer.IsDeleted = true;
                customer.Delete_DateTime = DateTime.Now;
               await _context.SaveChangesAsync();
                return new ResultDto()
                {
                    IsSuccess = true,
                    Message = Alert.GetRemoveAlert(Alert.Entity.customer),
                    StatusCode = System.Net.HttpStatusCode.OK
                };
            }
            catch (Exception)
            {

                return new ResultDto
                {
                    IsSuccess = false,
                    Message=Alert.Public.ServerException.GetDescription(),
                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                };
            }
        }

        public async Task<ResultDto> UpdateCustomer(UpdateCustomer_dto req)
        {
            try
            {
                var customer = await _context.Customers.FindAsync(req.Id);
                if (customer==null)
                {
                    return new ResultDto
                    {
                        IsSuccess = false,
                        Message = Alert.Public.NotFound.GetDescription(),
                        StatusCode=System.Net.HttpStatusCode.NotFound
                    };
                }
                customer.FirstName = req.FirstName;
                customer.LastName = req.LastName;
                customer.Email = req.Email;
                customer.Phone = req.Phone;
                customer.Address = req.Address;
                customer.City = req.City;
                customer.Ostan=req.Ostan;
                customer.ZipCode = req.ZipCode;
                await _context.SaveChangesAsync();
                return new ResultDto()
                {
                    IsSuccess = true,
                    Message = Alert.GetEditAlert(Alert.Entity.customer),
                    StatusCode = System.Net.HttpStatusCode.OK
                };
            }
            catch (Exception)
            {

                return new ResultDto
                {
                    Message = Alert.Public.ServerException.GetDescription(),
                    IsSuccess = false,
                    StatusCode = System.Net.HttpStatusCode.NotFound
                };
            }
        }
    }
}
