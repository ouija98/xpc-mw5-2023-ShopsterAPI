using Bogus;
using Microsoft.AspNetCore.Mvc;
using projekt.Entities;
using projekt.Repositories;
using System.Drawing;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommodityController : ControllerBase
    {


        private readonly ILogger<CommodityController> _logger;

        public CommodityController(ILogger<CommodityController> logger)
        {
            _logger = logger;
        }







        [HttpGet("Get all commodities")]
        public void Get()
        {

        }

        [HttpGet("Get a commodity by Id")]

        //[HttpGet(Name = "GetCommodity")]
        public void GetById(string Id)
        {


            //return IEnumerable<CommodityEntity>;
        }

        [HttpDelete("Delete a commodity by Id")]
        public void Delete(string Id)
        {

        }
        
        [HttpPut("Update a commodity by Id")]
        public void Update(string Id)
        {

        
        }
        [HttpPost("Add a randomly generated commodity")]
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


            var myCommodity = faker.Generate(1);

            return (IEnumerable<CommodityEntity>)myCommodity;
        }
        /*
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
        */
    }
}