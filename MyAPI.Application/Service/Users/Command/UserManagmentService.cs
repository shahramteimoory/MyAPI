using MyApi.Common;
using MyApi.Common.Dto;
using MyAPI.Application.Interface.Context;
using MyAPI.Domain.Entities;

namespace MyAPI.Application.Service.Users.Command
{
    public class UserManagmentService : IUserManagmentService
    {
        private readonly IDataBaseContext _context;
        public UserManagmentService(IDataBaseContext context)
        {
            _context=context;
        }
        public ResultDto CreateUser(CreateUser_Dto req)
        {
            try
            {
                User user = new User()
                {
                    Email = req.Email,
                    Password = Hasher.Hash(req.Password),

                };

                _context.Users.Add(user);
                _context.SaveChanges();
                return new ResultDto()
                {
                    IsSuccess = true,
                    Message = Alert.Public.Success.GetDescription(),
                    StatusCode = System.Net.HttpStatusCode.Created
                };
            }
            catch (Exception)
            {

                return new ResultDto
                {
                    IsSuccess = false,
                    Message = Alert.Public.ServerException.GetDescription(),
                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                };
            }
        }

        public ResultDto DeleteUser(long id)
        {
            try
            {
                var user = _context.Users.Find(id);
                if (user == null)
                {
                    return new ResultDto
                    {
                        IsSuccess = false,
                        Message = Alert.Public.NotFound.GetDescription(),
                        StatusCode = System.Net.HttpStatusCode.NotFound
                    };
                }
                user.IsDeleted = true;
                user.Delete_DateTime = DateTime.Now;
                _context.SaveChanges();
                return new ResultDto()
                {
                    IsSuccess = true,
                    Message = Alert.Public.Success.GetDescription(),
                    StatusCode = System.Net.HttpStatusCode.NoContent
                };
            }
            catch (Exception)
            {

                return new ResultDto
                {
                    IsSuccess = false,
                    Message = Alert.Public.ServerException.GetDescription(),
                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                };
            }
        }

        public ResultDto EditUser(EditUser_Dto req)
        {
            try
            {
                var user = _context.Users.Find(req.Id);
                if (user ==null)
                {
                    return new ResultDto
                    {
                        IsSuccess = false,
                        Message = Alert.Public.NotFound.GetDescription(),
                        StatusCode = System.Net.HttpStatusCode.NotFound
                    };
                }
                user.Email = req.Email;
                user.Password =Hasher.Hash(req.Password);
                _context.SaveChanges();
                return new ResultDto
                {
                    IsSuccess = true,
                    Message = Alert.Public.Success.GetDescription(),
                    StatusCode = System.Net.HttpStatusCode.OK
                };
            }
            catch (Exception)
            {

                return new ResultDto
                {
                    IsSuccess = true,
                    Message = Alert.Public.ServerException.GetDescription(),
                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                };
            }
        }
    }
}
