using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using NuGet.Protocol;
using Permission.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Permission.test.PermissionIntegrationTest
{
    public class MangersControllerIntrgrationTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public MangersControllerIntrgrationTest(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }
        string TestContext  = null!;

        [Fact]
        public async void GetAllMangertest()
        {
            await using var application = new WebApplicationFactory<Program>();
            using var client = application.CreateClient();
            var response = await client.GetAsync("/api/NewManger");
            var data = await response.Content.ReadAsStringAsync();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task ShouldReturnSuccessResponseGetById()
        {

            await using var application = new WebApplicationFactory<Program>();
            using var client = application.CreateClient();
            var response = await client.GetAsync("/api/NewManger/2");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            // Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType?.ToString());

            var result = await response.Content.ReadAsStringAsync();
            Assert.Equal( "{\"id\":2,\"name\":\"Ahmed\"}", result);
        }

          [Fact]
        public async Task ShouldReturnSuccessResponse3()
        {
            await using var application = new WebApplicationFactory<Program>();
            using var client = application.CreateClient();
            var a = new Manger
            {
                Id = 3,
                Name = "hassan"
            };
            var response = await client.PostAsJsonAsync("api/NewManger/", a);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType?.ToString());

            var result = await response.Content.ReadAsStringAsync();
            Assert.Equal("{\"id\":3,\"name\":\"hassan\"}", result);
        }

        [Fact]
        public async Task DateJsonStringConversionTest()
        {

            await using var application = new WebApplicationFactory<Program>();
            using var client = application.CreateClient();

            var response = await client.PostAsync("api/NewManger/", new StringContent(@"{""id"":4,""name"":""hassan""}", Encoding.UTF8, "application/json"));

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType?.ToString());

            var result = await response.Content.ReadAsStringAsync();
            Assert.Equal("{\"id\":4,\"name\":\"hassan\"}", result);
        }
    }


}
