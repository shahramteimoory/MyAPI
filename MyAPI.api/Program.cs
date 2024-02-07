using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MyAPI.Application.Interface.Context;
using MyAPI.Application.Interface.FaccadPatern;
using MyAPI.Application.Service.Products.Facad;
using MyAPI.Application.Service.Users.Facad;
using MyAPI.Persistance.Contexts;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IDataBaseContext, DataBaseContext>();
builder.Services.AddScoped<ICustomerFacadPatern, MyAPI.Application.Service.Customers.Facad.CustomerFacadPatern>();
builder.Services.AddScoped<IUserFacadPatern, UserFacadPatern>();
builder.Services.AddScoped<IProductFacadPatern, ProductFacadPatern>();
builder.Services.AddSingleton<FileExtensionContentTypeProvider>();
// Add services to the container.
builder.Services.AddDbContext<DataBaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("connectionString")));
builder.Services.AddControllers(options =>
{
    options.ReturnHttpNotAcceptable=true;
}).AddXmlDataContractSerializerFormatters();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddResponseCaching();
//var key = Encoding.ASCII.GetBytes(builder.Configuration(["Secret:Secret"]));
builder.Services.AddAuthentication("Bearer").AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = true;
    options.SaveToken = true;
    options.TokenValidationParameters = new()
    {

        ValidateIssuer = true,
        ValidateIssuerSigningKey = true,
        ValidateAudience = true,
        ValidIssuer= builder.Configuration["Secret:Issuer"],
        ValidAudience = builder.Configuration["Secret:Audience"],
        IssuerSigningKey=new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Secret:Secret"]))
    };
});

//{
//    option.DefaultAuthenticateScheme=JwtBearerDefaults.AuthenticationScheme;
//    option.DefaultChallengeScheme=JwtBearerDefaults.AuthenticationScheme;
//})
     //.AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
     //{
     //    options.RequireHttpsMetadata = true;
     //    options.SaveToken=true;
     //    options.TokenValidationParameters =
     //      new Microsoft.IdentityModel.Tokens.TokenValidationParameters
     //      {
     //          ValidateIssuerSigningKey = true,
     //          IssuerSigningKey=new SymmetricSecurityKey(key),
     //          ValidateIssuer = false,
     //          ValidateAudience =false,
     //      };
     //});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseResponseCaching();
app.Run();
