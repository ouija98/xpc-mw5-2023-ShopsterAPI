using Bogus;
using Microsoft.AspNetCore.Mvc;
using projekt.Entities;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ManufacturerController : ControllerBase
    {

        [HttpGet(Name = "GetManufacturers")]
        public void Get()
        {

        }
        
        [HttpPut(Name = "UpdateManufacturer")]
        public void Update()
        {

        }
        
        [HttpDelete(Name = "DeleteManufacturer")]
        public void Delete()
        {

        }
        
        [HttpPost(Name = "AddManufacturer")]
        public IEnumerable<ManufacturerEntity> Add()
        {
            var faker = new Faker<ManufacturerEntity>()
            .RuleFor(p => p.Id, f => f.Random.Guid())
            .RuleFor(p => p.Name, f => f.Lorem.Word())
            .RuleFor(p => p.Description, f => String.Join(" ", f.Lorem.Words()))
            .RuleFor(p => p.Logo, f => f.Lorem.Word() + ".jpg")
            .RuleFor(p => p.CountryOfOrigin, f => f.Address.Country());

            var myManufacturer = faker.Generate(1);

            return (IEnumerable<ManufacturerEntity>)myManufacturer;
        }
        

    }
}
