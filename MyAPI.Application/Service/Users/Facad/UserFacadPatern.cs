using MyAPI.Application.Interface.Context;
using MyAPI.Application.Interface.FaccadPatern;
using MyAPI.Application.Service.Users.Command;
using MyAPI.Application.Service.Users.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAPI.Application.Service.Users.Facad
{
    public class UserFacadPatern : IUserFacadPatern
    {
        private readonly IDataBaseContext _context;
        public UserFacadPatern(IDataBaseContext context)
        {
            _context=context;
        }
        private IUserManagmentService? _UserManagmentService;
        public IUserManagmentService UserManagmentService
        {
            get
            {
                return _UserManagmentService = _UserManagmentService ?? new UserManagmentService(_context);
            }
        }
        private IGetUserManagmentService? _GetUserManagmentService;
        public IGetUserManagmentService GetUserManagmentService
        {
            get
            {
                return _GetUserManagmentService = _GetUserManagmentService ?? new GetUserManagmentService(_context);
            }
        }
    }
}
