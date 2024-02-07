using ClientWebAplication.Dto;
using ClientWebAplication.Models.Customers;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClientWebAplication.Repositoreis.CustomerRepositories
{
    public interface ICustomerManagmentService
    {
        ResultDto<List<Models.Customers.Customer>> GetAllCustomer();
        ResultDto<Models.Customers.Customer> GetCustomerById(long Id);
        ResultDto AddCustomer(AddCustomer_Dto req);
        ResultDto UpdateCustomer(UpdateCustomer_dto req);
        ResultDto DeleteCustomer(long Id);
    }
    public class CustomerManagmentService: ICustomerManagmentService
    {
       private string ApiUrl = "https://localhost:44319/Customer";
       private HttpClient _client;
        public CustomerManagmentService()
        {
            _client = new HttpClient();
        }

        public ResultDto AddCustomer(AddCustomer_Dto req)
        {
            try
            {
                string jsonreq = JsonSerializer.Serialize(req);
                StringContent content= new StringContent(jsonreq,System.Text.Encoding.UTF8,"application/json");
                var res=_client.PostAsync(ApiUrl,content).Result;
                if (!res.IsSuccessStatusCode)
                {
                    return new ResultDto
                    {
                        IsSuccess = false,
                        Message = res.IsSuccessStatusCode.ToString(),
                    };
                }
                string responseJson = res.Content.ReadAsStringAsync().Result;
                CustomerDto result = JsonSerializer.Deserialize<CustomerDto>(responseJson);
                return new ResultDto { IsSuccess = result.isSuccess,Message= result.message };
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ResultDto DeleteCustomer(long Id)
        {
            try
            {
                var result = _client.DeleteAsync(ApiUrl + "/" + Id).Result;
                if (!result.IsSuccessStatusCode)
                {
                    return new ResultDto
                    {
                        IsSuccess = false,
                        Message = result.IsSuccessStatusCode.ToString(),
                    };
                }
                string responseJson = result.Content.ReadAsStringAsync().Result;
                CustomerDto res = JsonSerializer.Deserialize<CustomerDto>(responseJson);
                return new ResultDto { IsSuccess = res.isSuccess, Message = res.message };
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ResultDto<List<Customer>> GetAllCustomer()
        {
            try
            {
                var result = _client.GetStringAsync(ApiUrl).Result;
                GetCustomerRot ResList = JsonSerializer.Deserialize<GetCustomerRot>(result);

                if (!ResList.isSuccess)
                {
                    return new ResultDto<List<Customer>>
                    {
                        IsSuccess = false,
                        Message = ResList.message
                    };
                }
                return new ResultDto<List<Customer>>
                {
                    IsSuccess = true,
                    Data = ResList.data,
                    Message = ResList.message
                };
            }
            catch (Exception)
            {

                return new ResultDto<List<Customer>> { IsSuccess = false, Message = "خطایی رخ داده" };
            }
        }

        public ResultDto<Customer> GetCustomerById(long Id)
        {
            try
            {
                var result = _client.GetStringAsync(ApiUrl+"/"+ Id).Result;
                GetCustomerByIdRot Resist = JsonSerializer.Deserialize<GetCustomerByIdRot>(result);
                if (!Resist.isSuccess)
                {
                    return new ResultDto<Customer>
                    {
                        IsSuccess = false,
                        Message = Resist.message
                    };
                }
                return new ResultDto<Customer>
                {
                    IsSuccess = true,
                    Data = Resist.data,
                    Message = Resist.message
                };
            }
            catch (Exception)
            {

                return new ResultDto<Customer> { IsSuccess = false, Message = "خطایی رخ داده" };
            }
        }

        public ResultDto UpdateCustomer(UpdateCustomer_dto req)
        {
            try
            {
                string jsonreq = JsonSerializer.Serialize(req);
                StringContent content = new StringContent(jsonreq, System.Text.Encoding.UTF8, "application/json");
                var res = _client.PutAsync(ApiUrl, content).Result;

                if (!res.IsSuccessStatusCode)
                {
                    return new ResultDto
                    {
                        IsSuccess = false,
                        Message = res.IsSuccessStatusCode.ToString(),
                    };
                }
                string responseJson = res.Content.ReadAsStringAsync().Result;
                CustomerDto result = JsonSerializer.Deserialize<CustomerDto>(responseJson);
                return new ResultDto { IsSuccess = result.isSuccess, Message = result.message };
            }
            catch (Exception)
            {

                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "خطایی رخ داده"
                };
            }
        }
    }
    public class CustomerDto
    {
        public bool isSuccess { get; set; }
        public string message { get; set; }
    }
    public class GetCustomerRot
    {
        public bool isSuccess { get; set; }
        public string message { get; set; }
        public List<Customer> data { get; set; }
    }
    public class GetCustomerByIdRot
    {
        public bool isSuccess { get; set; }
        public string message { get; set; }
        public Customer data { get; set; }
    }
    public class AddCustomer_Dto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Ostan { get; set; }
        public string ZipCode { get; set; }
    }
    public class UpdateCustomer_dto
    {
        public long id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string ostan { get; set; }
        public string zipCode { get; set; }
    }
}
