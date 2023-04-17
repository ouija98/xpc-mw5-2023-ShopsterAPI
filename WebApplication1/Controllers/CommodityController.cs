using Bogus;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Entities;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    /// <summary>
    /// Controller for managing commodities.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class CommodityController : ControllerBase
    {
        private readonly ILogger<CommodityController> _logger;
        private readonly IRepository<CommodityEntity> _commodityRepository;

        /// <summary>
        /// Creates a new instance of the <see cref="CommodityController"/> class.
        /// </summary>
        /// <param name="logger">The logger instance.</param>
        /// <param name="commodityRepository">The repository for managing commodities.</param>
        public CommodityController(ILogger<CommodityController> logger,
            IRepository<CommodityEntity> commodityRepository)
        {
            _logger = logger;
            _commodityRepository = commodityRepository;
        }

        /// <summary>
        /// Retrieves all commodities.
        /// </summary>
        /// <returns>An enumerable collection of all commodities.</returns>
        [HttpGet("Get all commodities")]
        public IEnumerable<CommodityEntity> Get()
        {
            return _commodityRepository.GetAll();
        }

        /// <summary>
        /// Retrieves a commodity by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the commodity to retrieve.</param>
        /// <returns>The commodity with the specified identifier.</returns>
        [HttpGet("Get a commodity by Id/{id}")]
        public ActionResult<CommodityEntity> GetById(Guid id)
        {
            var commodity = _commodityRepository.GetById(id);

            if (commodity == null)
            {
                return NotFound();
            }

            return commodity;
        }

        /// <summary>
        /// Updates a commodity by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the commodity to update.</param>
        /// <param name="commodity">The updated commodity.</param>
        [HttpPut("Update a commodity by Id/{id}")]
        public IActionResult Update(Guid id, [FromBody] CommodityEntity commodity)
        {
            if (commodity == null || commodity.Id != id)
            {
                return BadRequest();
            }

            var existingCommodity = _commodityRepository.GetById(id);

            if (existingCommodity == null)
            {
                return NotFound();
            }

            existingCommodity.Name = commodity.Name;
            existingCommodity.Picture = commodity.Picture;
            existingCommodity.Description = commodity.Description;
            existingCommodity.Price = commodity.Price;
            existingCommodity.Weight = commodity.Weight;
            existingCommodity.Quantity = commodity.Quantity;
            existingCommodity.Category = commodity.Category;
            existingCommodity.Manufacturer = commodity.Manufacturer;
            //existingCommodity.Ratings = commodity.Ratings;

            _commodityRepository.Update(existingCommodity);
            Database.Instance.SaveChanges();

            return NoContent();
        }

        /// <summary>
        /// Deletes a commodity by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the commodity to delete.</param>
        [HttpDelete("Delete a commodity by Id/{id}")]
        public IActionResult Delete(Guid id)
        {
            var existingCommodity = _commodityRepository.GetById(id);

            if (existingCommodity == null)
            {
                return NotFound();
            }

            _commodityRepository.Delete(id);
            Database.Instance.SaveChanges();

            return NoContent();
        }

        /// <summary>
        /// Adds a randomly generated commodity to the collection.
        /// </summary>
        /// <returns>The added commodity.</returns>
        [HttpPost("Add a randomly generated commodity")]
        public ActionResult<CommodityEntity> Add()
        {
            var faker = new Faker<CommodityEntity>()
                .RuleFor(p => p.Id, f => f.Random.Guid())
                .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                .RuleFor(p => p.Picture, f => f.Lorem.Word() + ".jpg")
                .RuleFor(p => p.Description, f => String.Join(" ", f.Lorem.Words()))
                .RuleFor(p => p.Price, f => Convert.ToDecimal(f.Commerce.Price()))
                .RuleFor(p => p.Weight, f => f.Random.Number(1, 100))
                .RuleFor(p => p.Quantity, f => f.Random.Number(1, 100))
                .RuleFor(p => p.Category,
                    f => new CategoryEntity { Id = f.Random.Guid(), Name = f.Commerce.Categories(1)[0] })
                .RuleFor(p => p.Manufacturer,
                    f => new ManufacturerEntity { Id = f.Random.Guid(), Name = f.Company.CompanyName() })
                .RuleFor(p => p.Ratings, f => Enumerable.Range(1, f.Random.Number(1, 5))
                    .Select(_ => new RatingEntity
                    {
                        Id = f.Random.Guid(), Stars = f.Random.Number(1, 5), Title = f.Lorem.Word(),
                        Description = f.Lorem.Paragraph(), CommodityEntityId = f.Random.Guid()
                    }));

            CommodityEntity myCommodity = faker.Generate();
            _commodityRepository.Create(myCommodity);

            return CreatedAtAction(nameof(GetById), new { id = myCommodity.Id }, myCommodity);
        }


        [HttpPost("Add a commodity")]
        public IActionResult AddFromBody([FromBody] CommodityEntity commodity)
        {
            if (commodity == null)
            {
                return BadRequest("The commodity object is null");
            }

            try
            {
                // Insert the commodity into the database
                commodity.Id = Guid.NewGuid();
                Database.Instance.Add(commodity);
                Database.Instance.SaveChanges();
                return CreatedAtAction(nameof(GetById), new { id = commodity.Id }, commodity);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error inserting the commodity: {ex.Message}");
            }
        }
    }
}