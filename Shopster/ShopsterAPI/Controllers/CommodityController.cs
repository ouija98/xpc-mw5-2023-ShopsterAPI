using Microsoft.AspNetCore.Mvc;
using Shopster.Entities;
using Shopster.Shopster.DAL.Repositories;

namespace Shopster.ShopsterAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommodityController : ControllerBase
    {
        private readonly ILogger<CommodityController> _logger;
        private readonly IRepository<CommodityEntity> _commodityRepository;

        public CommodityController(ILogger<CommodityController> logger, IRepository<CommodityEntity> commodityRepository)
        {
            _logger = logger;
            _commodityRepository = commodityRepository;
        }

        [HttpGet]
        public IEnumerable<CommodityEntity> Get()
        {
            _logger.LogInformation("Getting all commodities");
            return _commodityRepository.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<CommodityEntity> GetById(Guid id)
        {
            _logger.LogInformation($"Getting commodity with id {id}");
            var commodity = _commodityRepository.GetById(id);

            if (commodity == null)
            {
                _logger.LogWarning($"Commodity with id {id} not found");
                return NotFound();
            }

            return commodity;
        }

        [HttpPost]
        public IActionResult Add([FromBody] CommodityEntity commodity)
        {
            if (commodity == null)
            {
                _logger.LogError("Commodity object is null");
                return BadRequest("The commodity object is null");
            }

            try
            {
                _logger.LogInformation($"Inserting new commodity with name {commodity.Name}");
                // Insert the commodity into the database
                commodity.Id = Guid.NewGuid();
                _commodityRepository.Create(commodity);
                return CreatedAtAction(nameof(GetById), new { id = commodity.Id }, commodity);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error inserting the commodity: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error inserting the commodity: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] CommodityEntity commodity)
        {
            if (commodity == null || commodity.Id != id)
            {
                _logger.LogError($"Invalid commodity object or commodity ID: {id}");
                return BadRequest();
            }

            var existingCommodity = _commodityRepository.GetById(id);

            if (existingCommodity == null)
            {
                _logger.LogWarning($"Commodity with id {id} not found");
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

            _logger.LogInformation($"Updating commodity with id {id}");
            _commodityRepository.Update(existingCommodity);

            return Ok(existingCommodity);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var existingCommodity = _commodityRepository.GetById(id);

            if (existingCommodity == null)
            {
                _logger.LogWarning($"Commodity with id {id} not found");
                return NotFound();
            }

            try
            {
                _logger.LogInformation($"Deleting commodity with id {id}");
                _commodityRepository.Delete(id);

                return Ok(existingCommodity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting commodity with ID {id}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error deleting the commodity: {ex.Message}");
            }
        }

    }
}
