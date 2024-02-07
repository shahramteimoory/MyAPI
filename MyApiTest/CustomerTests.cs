using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace MyApiTest
{
    
    //https://www.youtube.com/watch?v=xs8gNQjCXw0
    [TestClass]
    public class CustomerTests
    {
        private HttpClient _client;
        public CustomerTests()
        {
            var _server = new WebApplicationFactory<Program>();
            var _client = _server.CreateClient();

        }
        [TestMethod]
        public void CustomerGetAllTest()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,"Customer");
            var response= _client.SendAsync(request).Result;

            Assert.AreEqual(HttpStatusCode.OK,response.StatusCode);
        }
    }

}
