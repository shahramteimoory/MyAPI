using MyApi.Common;
using MyApi.Common.Dto;
using MyAPI.Application.Interface.Context;
using MyAPI.Domain.Entities;

namespace MyAPI.Application.Service.Products.Command
{
    public class ProductManagmentService : IProductManagmentService
    {
        private readonly IDataBaseContext _context;
        public ProductManagmentService(IDataBaseContext context)
        {
            _context=context;
        }
        public async Task<ResultDto> DeleteProduct(long id)
        {
            try
            {
                var product=await _context.Products.FindAsync(id);
                if (product == null)
                {
                    return new ResultDto()
                    {
                        IsSuccess = false,
                        Message = Alert.Public.NotFound.GetDescription()
                    };
                }
                product.IsDeleted = true;
                product.Delete_DateTime = DateTime.Now;
               await _context.SaveChangesAsync();
                return new ResultDto()
                {
                    IsSuccess = true,
                    Message = Alert.GetRemoveAlert(Alert.Entity.Product)
                };
            }
            catch (Exception)
            {

                return new ResultDto
                {
                    IsSuccess = false,
                    Message = Alert.Public.ServerException.GetDescription()
                };
            }
        }

        public async Task<ResultDto> EditProduct(EditProduct_Dto req)
        {
            try
            {
                var product = await _context.Products.FindAsync(req.Id);
                if (product==null)
                {
                    return new ResultDto
                    {
                        IsSuccess = false,
                        Message = Alert.Public.NotFound.GetDescription()
                    };
                }
                product.ProductName = req.ProductName;
                product.Size= req.Size;
                product.Nooeh = req.Nooeh;
                product.Price = req.Price;
                product.Status = req.Status;
               await _context.SaveChangesAsync();
                return new ResultDto()
                {
                    IsSuccess = true,
                    Message = Alert.GetEditAlert(Alert.Entity.Product)
                };
            }
            catch (Exception)
            {

                return new ResultDto
                {
                    IsSuccess = false,
                    Message = Alert.Public.ServerException.GetDescription()
                };
            }
        }

        public async Task<ResultDto> InsertProduct(InsertProduct_Dto req)
        {
            try
            {
                Product product = new Product()
                {
                    Size = req.Size,
                    Status = req.Status,
                    Nooeh = req.Nooeh,
                    Price = req.Price,
                    ProductName = req.ProductName,
                };
               await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();
                return new ResultDto()
                {
                    IsSuccess = true,
                    Message = Alert.GetAddAlert(Alert.Entity.Product)
                };
            }
            catch (Exception)
            {

                return new ResultDto
                {
                    IsSuccess = false,
                    Message = Alert.Public.ServerException.GetDescription()
                };
            }
        }
    }
}
