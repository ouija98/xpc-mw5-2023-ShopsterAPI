﻿using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Shopster.DAL;
using Shopster.DAL.Repositories;
using Shopster.Tests.APItests.Fixtures;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Azure;
using Bogus.DataSets;
using Newtonsoft.Json;
using Shopster.DAL.Entities;
using Shopster.DTOs;
using System.Runtime.ConstrainedExecution;

namespace Shopster.Tests.APItests
{
    public class CategoryRepositoryFixture
    {


        public class CategoryEndpoints : IntegrationTests
        {
            private readonly CategoryRepositoryFixture repositoryFixture;

            public CategoryEndpoints(ApiWebApplicationFactory fixture) : base(fixture)
            {

            }


            [Fact]
            public async Task Should_AllCategories()
            {
                var response = await _client.GetAsync("Category");


                response.StatusCode.Should().Be(HttpStatusCode.OK);
                var responseBody = await response.Content.ReadAsStringAsync();
                responseBody.Should().Be("[{\"id\":\"0b20aa29-d57a-4ce0-ba3b-1bdbd0c98f8c\",\"name\":\"ctg5\"},{\"id\":\"31b10bdd-dbd6-4301-90b5-2947181f0760\",\"name\":\"ctg6\"},{\"id\":\"cb0ff0ef-c4bf-4010-88b4-31550ff157dc\",\"name\":\"ctg1\"},{\"id\":\"f463a390-12f3-4efc-b9ca-5518562dfd5b\",\"name\":\"ctg3\"}]");
                
                var categories = JsonConvert.DeserializeObject<List<CategoryEntity>>(responseBody);
                categories.Should().HaveCount(4);

                categories[0].Name.Should().Be("ctg5");
            }

            [Fact]
            public async Task Should_NewCategory()
            {
                var newCategory = new CategoryEntity
                {
                    //Id = Guid.NewGuid(),
                    Name = "ctg10"
                };

                var newCategorySerialized = JsonConvert.SerializeObject(newCategory);
                var stringContent = new StringContent(newCategorySerialized, Encoding.UTF8, "application/json");

                var response = await _client.PostAsync("Category", stringContent);
                response.StatusCode.Should().Be(HttpStatusCode.OK);

                var responseBody = await response.Content.ReadAsStringAsync();
                responseBody.Should().NotBeEmpty();

                var categoryDetail = JsonConvert.DeserializeObject<CategoryEntity>(await response.Content.ReadAsStringAsync());
                categoryDetail.Name.Should().Be("ctg10");

            }


            [Fact]
            public async Task Should_DeleteCategory()
            {
                var categoryToBeDeletedGuid = new Guid("0b20aa29-d57a-4ce0-ba3b-1bdbd0c98f8c");

                var response = await _client.DeleteAsync($"Category/{categoryToBeDeletedGuid}");

                response.StatusCode.Should().Be(HttpStatusCode.OK);

            }


            
            [Fact]
            public async Task Should_UpdateCategory()
            {
                Guid categoryToBeUpdatedGuid = new Guid("31b10bdd-dbd6-4301-90b5-2947181f0760");
                var categoryUpdate = new CategoryEntity
                {
                    Id = categoryToBeUpdatedGuid,
                    Name = "ctg11"
                };
                var categoryUpdateSerialized = JsonConvert.SerializeObject(categoryUpdate);
                var stringContent = new StringContent(categoryUpdateSerialized, Encoding.UTF8, "application/json");


                var response = await _client.PutAsync($"Category/{categoryToBeUpdatedGuid}",stringContent);


                response.StatusCode.Should().Be(HttpStatusCode.OK);

                var categoryDetail = JsonConvert.DeserializeObject<CategoryEntity>(await response.Content.ReadAsStringAsync());
                categoryDetail.Id.Should().Be(categoryToBeUpdatedGuid);


            }

            [Fact]
            public async Task Should_CategoriyById()
            {
                Guid categoryGuid = new Guid("31b10bdd-dbd6-4301-90b5-2947181f0760");

                var response = await _client.GetAsync($"Category/{categoryGuid}");

                response.StatusCode.Should().Be(HttpStatusCode.OK);
                var categoryDetail = JsonConvert.DeserializeObject<CategoryEntity>(await response.Content.ReadAsStringAsync());
                categoryDetail.Id.Should().Be(categoryGuid);
                categoryDetail.Name.Should().Be("ctg11");

            }




        }

    }
}
