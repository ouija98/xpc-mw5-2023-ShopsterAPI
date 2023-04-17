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
        [HttpGet]
        public IEnumerable<CommodityEntity> Get()
        {
            return _commodityRepository.GetAll();
        }

        /// <summary>
        /// Retrieves a commodity by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the commodity to retrieve.</param>
        /// <returns>The commodity with the specified identifier.</returns>
        [HttpGet("{id}")]
        public ActionResult<CommodityEntity> GetById(Guid id)
        {
            var commodity = _commodityRepository.GetById(id);

            if (commodity == null)
            {
                return NotFound();
            }

            return commodity;
        }



        [HttpPost]
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

        /// <summary>
        /// Updates a commodity by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the commodity to update.</param>
        /// <param name="commodity">The updated commodity.</param>
        [HttpPut("{id}")]
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
        [HttpDelete("{id}")]
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
    }
}