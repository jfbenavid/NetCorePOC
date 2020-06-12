namespace TestApiRest.API.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Newtonsoft.Json;
    using RestSharp;
    using TestApiRest.Model;

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        public ActionResult Post(Logon credentials)
        {
            if (string.IsNullOrEmpty(credentials.Username) || string.IsNullOrEmpty(credentials.Password))
            {
                return BadRequest(new { Error = "The username and the password must be provided." });
            }

            var data = new AuthData
            {
                Audience = _configuration["Auth0:Audience"],
                ClientId = _configuration["Auth0:ClientId"],
                ClientSecret = _configuration["Auth0:ClientSecret"],
                GrantType = GrantTypes.ClientCredentials
            };

            var client = new RestClient($"{_configuration["Auth0:Domain"]}/oauth/token");
            var request = new RestRequest(Method.POST)
                .AddHeader("content-type", "application/json")
                .AddParameter(
                    "application/json",
                    JsonConvert.SerializeObject(data),
                    ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return Ok(response.Content);
            }

            return Unauthorized(response.Content);
        }
    }
}