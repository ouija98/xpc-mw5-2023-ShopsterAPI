using System.Text;
using FluentAssertions;
using Shopster.Tests.APItests.Fixtures;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using Shopster.DAL.Entities;

namespace Shopster.Tests.APItests
{
    public class ManufacturerEndpoints : IntegrationTests
    {
        public ManufacturerEndpoints(ApiWebApplicationFactory fixture) : base(fixture)
        {

        }


        [Fact]
        public async Task Should_AllManufacturers()
        {
            var response = await _client.GetAsync("Manufacturer");


            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var responseBody = await response.Content.ReadAsStringAsync();

            var manufacturers = JsonConvert.DeserializeObject<List<CategoryEntity>>(responseBody);
            manufacturers.Should().HaveCount(5);

            manufacturers[0].Name.Should().Be("manu300");
        }

        [Fact]
        public async Task Should_NewManufacturer()
        {
            Guid manufacturerGuid = new Guid("2e5d8b9d-1197-4dc0-8d77-08db524239aa");
            var newManufacturer = new ManufacturerEntity
            {
                Id = manufacturerGuid,
                Name = "manu300",
                Description = "desc300",
                Logo = "logo300",
                CountryOfOrigin = "CZ"          
            };

            var newManufacturerSerialized = JsonConvert.SerializeObject(newManufacturer);
            var stringContent = new StringContent(newManufacturerSerialized, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("Manufacturer", stringContent);
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var responseBody = await response.Content.ReadAsStringAsync();
            responseBody.Should().NotBeEmpty();

        }


        [Fact]
        public async Task Should_ManufacturerById()
        {
            Guid manufacturerGuid = new Guid("3578b053-ff12-40c1-8a11-e16e1680a286");

            var response = await _client.GetAsync($"Manufacturer/{manufacturerGuid}");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var manufacturerDetail = JsonConvert.DeserializeObject<ManufacturerEntity>(await response.Content.ReadAsStringAsync());
            manufacturerDetail.Id.Should().Be(manufacturerGuid);
            manufacturerDetail.Name.Should().Be("manu2");
            manufacturerDetail.Description.Should().Be("desc2");
            manufacturerDetail.Logo.Should().Be("logo2.png");
            manufacturerDetail.CountryOfOrigin.Should().Be("CZ");

        }



        [Fact]
        public async Task Should_UpdateManufacturer()
        {
            Guid manufacturerToBeUpdatedGuid = new Guid("5c87d5f2-7780-4feb-a4ac-b2aee9d5023f");
            var manufacturerUpdate = new ManufacturerEntity
            {
                Id = manufacturerToBeUpdatedGuid,
                Name = "manu700",
                Description = "desc300",
                Logo = "logo300",
                CountryOfOrigin = "CZ"
            };
            var manufacturerUpdateSerialized = JsonConvert.SerializeObject(manufacturerUpdate);
            var stringContent = new StringContent(manufacturerUpdateSerialized, Encoding.UTF8, "application/json");


            var response = await _client.PutAsync($"Manufacturer/{manufacturerToBeUpdatedGuid}", stringContent);


            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var manufacturerDetail = JsonConvert.DeserializeObject<CategoryEntity>(await response.Content.ReadAsStringAsync());
            manufacturerDetail.Id.Should().Be(manufacturerToBeUpdatedGuid);
        }


        [Fact]
        public async Task Should_DeleteManufacturer()
        {
            var manufacturerToBeDeletedGuid = new Guid("2e5d8b9d-1197-4dc0-8d77-08db524239aa");

            var response = await _client.DeleteAsync($"Manufacturer/{manufacturerToBeDeletedGuid}");

            response.StatusCode.Should().Be(HttpStatusCode.OK);

        }


    }
}
