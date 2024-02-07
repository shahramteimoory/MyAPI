using MyApi.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAPI.Application.Service.Users.Command
{
    public interface IUserManagmentService
    {
        ResultDto CreateUser(CreateUser_Dto req);
        ResultDto EditUser(EditUser_Dto req);
        ResultDto DeleteUser(long id);
    }
}
