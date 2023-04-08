using Bogus;
using Microsoft.AspNetCore.Mvc;
using projekt.Entities;
using System.Drawing;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommodityController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<CommodityController> _logger;

        public CommodityController(ILogger<CommodityController> logger)
        {
            _logger = logger;
        }

        





        [HttpGet(Name = "GetCommodities")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpDelete(Name = "DeleteCommodity")]
        public void Delete()
        {

        }
        
        [HttpPut(Name = "UpdateCommodity")]
        public void Update()
        {

        }
        [HttpPost(Name = "AddCommodity")]
        public IEnumerable<CommodityEntity> Add()
        {
            var faker = new Faker<CommodityEntity>()
                .RuleFor(p => p.Id, f => f.Random.Guid())
                .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                .RuleFor(p => p.Picture, f => f.Lorem.Word() + ".jpg")
                .RuleFor(p => p.Description, f => String.Join(" ", f.Lorem.Words()))
                .RuleFor(p => p.Price, f => Convert.ToDecimal(f.Commerce.Price()))
                .RuleFor(p => p.Weight, f => f.Random.Number(1, 100))
                .RuleFor(p => p.Quantity, f => f.Random.Number(1, 100));                
                //.RuleFor(p => p.Category, f => f.Commerce.Categories());


            var myProducts = faker.Generate(5);

            return (IEnumerable<CommodityEntity>)myProducts;
        }

    }
}