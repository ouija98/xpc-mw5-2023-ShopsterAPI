using Bogus;
using Microsoft.AspNetCore.Mvc;
using projekt.Entities;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RatingController : ControllerBase
    {
        [HttpGet(Name = "GetRatings")]
        public void Get()
        {

        }

        [HttpPut(Name = "UpdateRatings")]
        public void Update()
        {

        }

        [HttpDelete(Name = "DeleteRatings")]
        public void Delete()
        {

        }

        [HttpPost(Name = "AddRatings")]
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
