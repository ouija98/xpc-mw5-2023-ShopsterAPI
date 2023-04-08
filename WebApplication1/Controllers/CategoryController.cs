using Bogus;
using Microsoft.AspNetCore.Mvc;
using projekt.Entities;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {

        [HttpGet(Name = "GetCategories")]
        public void Get()
        {

        }

        [HttpPut(Name = "UpdateCategory")]
        public void Update()
        {

        }

        [HttpDelete(Name = "DeleteCategory")]
        public void Delete()
        {

        }

        [HttpPost(Name = "AddCategory")]
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
