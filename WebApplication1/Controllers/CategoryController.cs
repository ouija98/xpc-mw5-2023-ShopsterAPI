using Bogus;
using Microsoft.AspNetCore.Mvc;
using projekt.Entities;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {

        [HttpGet("Get all categories")]
        public void Get()
        {

        }

        [HttpGet("Get a category by Id")]
        public void GetById(string Id)
        {

        }

        [HttpPut("Update a category by Id")]
        public void Update(string Id)
        {

        }

        [HttpDelete("Delete a category by Id")]
        public void Delete(string Id)
        {

        }

        [HttpPost("Add a randomly generated category")]
        public IEnumerable<CategoryEntity> Add()
        {
            var faker = new Faker<CategoryEntity>()
            .RuleFor(p => p.Id, f => f.Random.Guid())
            .RuleFor(p => p.Title, f => String.Join(" ", f.Commerce.Categories(1)));

            var myCategory = faker.Generate(1);

            return (IEnumerable<CategoryEntity>)myCategory;
        }


    }
}
