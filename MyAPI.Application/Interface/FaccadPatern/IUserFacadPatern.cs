using MyAPI.Application.Service.Users.Command;
using MyAPI.Application.Service.Users.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAPI.Application.Interface.FaccadPatern
{
    public interface IUserFacadPatern
    {
        IUserManagmentService UserManagmentService { get; }
        IGetUserManagmentService GetUserManagmentService {  get; }
    }
}
