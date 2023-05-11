using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using CookBook.Api.Options;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using Xunit;

namespace Shopster.Tests.APItests.Fixtures
{
    public class IntegrationTests : IClassFixture<ApiWebApplicationFactory>
    {
        protected readonly ApiWebApplicationFactory _factory;
        protected readonly HttpClient _client;

        //tady potrebuju vytvaret klienta ktereho budu pouzivat na provolavani dotazu
        //do konstruktoru budu posilat moji fixture
        public IntegrationTests(ApiWebApplicationFactory fixture) 
        {
            _factory = fixture;
            //vytvoreni http klienta:
            _client = _factory.CreateClient();
        }
    }
}
