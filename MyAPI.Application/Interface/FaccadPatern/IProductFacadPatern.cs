using MyAPI.Application.Service.Products.Command;
using MyAPI.Application.Service.Products.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAPI.Application.Interface.FaccadPatern
{
    public interface IProductFacadPatern
    {
        IGetProductManagmentService GetProductManagmentService {  get; }
        IProductManagmentService ProductManagmentService {  get; }
    }
}
