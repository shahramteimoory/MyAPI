using MyAPI.Application.Interface.Context;
using MyAPI.Application.Interface.FaccadPatern;
using MyAPI.Application.Service.Products.Command;
using MyAPI.Application.Service.Products.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAPI.Application.Service.Products.Facad
{
    public class ProductFacadPatern : IProductFacadPatern
    {
        private readonly IDataBaseContext _context;
        public ProductFacadPatern(IDataBaseContext context)
        {
            _context=context;
        }
        private IGetProductManagmentService? _GetProductManagmentService;
        public IGetProductManagmentService GetProductManagmentService
        {
            get
            {
                return _GetProductManagmentService = _GetProductManagmentService ?? new GetProductManagmentService(_context);
            }
        }
        private IProductManagmentService? _ProductManagmentService;
        public IProductManagmentService ProductManagmentService
        {
            get
            {
                return _ProductManagmentService = _ProductManagmentService ?? new ProductManagmentService(_context);
            }
        }
    }
}
