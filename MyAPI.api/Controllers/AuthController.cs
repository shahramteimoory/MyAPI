using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MyAPI.Application.Interface.FaccadPatern;
using MyAPI.Application.Service.Users.Command;
using MyAPI.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace MyAPI.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IUserFacadPatern _userFacadPatern;
        public AuthController(IUserFacadPatern userFacadPatern, IConfiguration configuration)
        {
            _userFacadPatern = userFacadPatern;
            _configuration = configuration;

        }
        [HttpPost("Login")]
        public  IActionResult Login(string UserName,string password)
        {
            if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(password))
            {
                return BadRequest();
            }
          var result= _userFacadPatern.GetUserManagmentService.Login(UserName, password);
            if (!result.IsSuccess)
            {
                Response.StatusCode=(int)result.StatusCode;
                return Unauthorized(result);
            }
            var securitykey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(_configuration["Secret:Secret"])
                );
            var signinCredential = new SigningCredentials(securitykey,SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>()
            {
                new Claim("UserEmail",result.Data.Email),
                new Claim("UserId",result.Data.Id.ToString())
            };
            var jwtBerearToken = new JwtSecurityToken(
                _configuration["Secret:Issuer"], _configuration["Secret:Audience"], claims,DateTime.UtcNow,DateTime.UtcNow.AddDays(1), signinCredential
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(jwtBerearToken);
            var res = new ReturnToken
            {
                IsSuccess = result.IsSuccess,
                ExpireTime = DateTime.UtcNow.AddDays(1),
                Message = result.Message,
                token = jwt
            };
            Response.StatusCode = (int)result.StatusCode;
            return Json(res);
        }
        [HttpPost("Register")]
        public  IActionResult register(CreateUser_Dto req)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result= _userFacadPatern.UserManagmentService.CreateUser(req);
            Response.StatusCode = (int)result.StatusCode;
            return Json(result);
        }
    }
    public class ReturnToken
    {
        public string token { get; set; }=string.Empty;
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public DateTime ExpireTime { get; set; }
    }

}
