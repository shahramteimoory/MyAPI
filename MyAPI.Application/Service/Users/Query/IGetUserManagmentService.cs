using MyApi.Common.Dto;
using MyAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAPI.Application.Service.Users.Query
{
    public interface IGetUserManagmentService
    {
        ResultDto<List<User>> GetUsers();
        ResultDto<User> GetUser(long Id);
        ResultDto<User> Login(string Email,string Password);
    }
}
