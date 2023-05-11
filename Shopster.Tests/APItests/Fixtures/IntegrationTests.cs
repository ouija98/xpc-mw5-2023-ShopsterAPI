using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using Xunit;

namespace Shopster.Tests.APItests.Fixtures
{
    public class IntegrationTests : IClassFixture<ApiWebApplicationFactory>
    {
        protected readonly ApiWebApplicationFactory _factory;
        protected readonly HttpClient _client;
        protected readonly IConfiguration _configuration;


        public IntegrationTests(ApiWebApplicationFactory fixture) 
        {
            _factory = fixture;
            _client = _factory.CreateClient();
            _configuration = new ConfigurationBuilder()
              .AddJsonFile("integrationsettings.json")
              .Build();

            //var serverNameOptions = _configuration.GetSection("ServerName").Get<ServerNameOptions>();

        }
    }
}
