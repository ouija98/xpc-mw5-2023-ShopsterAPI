using Bogus;
using Microsoft.AspNetCore.Mvc;
using projekt.Entities;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RatingController : ControllerBase
    {
        [HttpGet("Get all ratings")]
        public void Get()
        {

        }

        [HttpGet("Get a rating by Id")]
        public void GetById(string Id)
        {

        }

        [HttpPut("Update a rating by Id")]
        public void Update(string Id)
        {

        }

        [HttpDelete("Delete a rating by Id")]
        public void Delete(string Id)
        {

        }

        [HttpPost("Add a randomly generated rating")]
        public IEnumerable<RatingEntity> Add()
        {
            var faker = new Faker<RatingEntity>()
            .RuleFor(p => p.Id, f => f.Random.Guid())
            .RuleFor(p => p.Stars, f => f.Random.Number(1, 5))
            .RuleFor(p => p.Title, f => Convert.ToString(f.Lorem.Word()))
            .RuleFor(p => p.Description, f => String.Join(" ", f.Lorem.Words()));

            var myReview = faker.Generate(1);

            return (IEnumerable<RatingEntity>)myReview;
        }


    }
}
