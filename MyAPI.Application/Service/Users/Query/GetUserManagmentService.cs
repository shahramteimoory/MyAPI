using MyApi.Common;
using MyApi.Common.Dto;
using MyAPI.Application.Interface.Context;
using MyAPI.Domain.Entities;

namespace MyAPI.Application.Service.Users.Query
{
    public class GetUserManagmentService : IGetUserManagmentService
    {
        private readonly IDataBaseContext _context;
        public GetUserManagmentService(IDataBaseContext context)
        {
            _context=context;
        }
        public ResultDto<User> GetUser(long Id)
        {
            try
            {
                var user = _context.Users.Find(Id);
                if (user == null)
                {
                    return new ResultDto<User>()
                    {
                        IsSuccess = false,
                        Message = Alert.Public.NotFound.GetDescription(),
                        StatusCode = System.Net.HttpStatusCode.NotFound
                    };
                }
                return new ResultDto<User>()
                {
                    IsSuccess=true,
                    Message = Alert.Public.Success.GetDescription(),
                    Data=user,
                    StatusCode = System.Net.HttpStatusCode.OK
                };
            }
            catch (Exception)
            {

                return new ResultDto<User>
                {
                    IsSuccess = false,
                    Message=Alert.Public.ServerException.GetDescription(),
                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                };
            }
        }

        public ResultDto<List<User>> GetUsers()
        {
            try
            {
                var users = _context.Users.ToList();
                if (users.Count==0)
                {
                    return new ResultDto<List<User>>
                    {
                        IsSuccess = false,
                        Message = Alert.Public.NotFound.GetDescription(),
                        Data = users,
                        StatusCode = System.Net.HttpStatusCode.NotFound
                    };
                }
                return new ResultDto<List<User>>
                {
                    IsSuccess = true,
                    Message = Alert.Public.Success.GetDescription(),
                    Data = users,
                    StatusCode = System.Net.HttpStatusCode.OK
                };
            }
            catch (Exception)
            {

                return new ResultDto<List<User>> 
                { IsSuccess = false,Message=Alert.Public.ServerException.GetDescription(),StatusCode = System.Net.HttpStatusCode.InternalServerError};
            };
        }

        public ResultDto<User> Login(string Email, string Password)
        {
            try
            {
                var user = _context.Users.Where(u => u.Email == Email).FirstOrDefault();
                if (user==null)
                {
                    return new ResultDto<User>
                    {
                        IsSuccess = false,
                        Message = Alert.Public.NotFound.GetDescription(),
                        StatusCode = System.Net.HttpStatusCode.NotFound
                    };
                }
                bool verify=Hasher.Verify(Password,user.Password);
                if (verify==false)
                {
                    return new ResultDto<User>
                    {
                        IsSuccess = false,
                        Message = "ایمیل یا کلمه عبور اشتباه وارد شده است",
                        StatusCode = System.Net.HttpStatusCode.Unauthorized
                    };
                }
                return new ResultDto<User>
                {
                    IsSuccess = true,
                    Message = Alert.Public.Success.GetDescription(),
                    Data = user,
                    StatusCode = System.Net.HttpStatusCode.OK
                };
            }
            catch (Exception)
            {

                return new ResultDto<User> { IsSuccess = false,Message=Alert.Public.ServerException.GetDescription(),StatusCode=System.Net.HttpStatusCode.InternalServerError};
            }
        }
    }
}
