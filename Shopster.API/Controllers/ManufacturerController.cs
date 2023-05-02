using Microsoft.AspNetCore.Mvc;
using Shopster.DAL.Entities;
using Shopster.DAL.Repositories;

namespace Shopster.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ManufacturerController : ControllerBase
    {
        private readonly ILogger<ManufacturerController> _logger;
        private readonly IRepository<ManufacturerEntity> _manufacturerRepository;

        public ManufacturerController(ILogger<ManufacturerController> logger,
            IRepository<ManufacturerEntity> manufacturerRepository)
        {
            _logger = logger;
            _manufacturerRepository = manufacturerRepository;
        }

        [HttpGet]
        public IEnumerable<ManufacturerEntity> Get()
        {
            _logger.LogInformation("Retrieving all manufacturers");
            return _manufacturerRepository.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<ManufacturerEntity> GetById(Guid id)
        {
            _logger.LogInformation("Retrieving manufacturer by ID {id}", id);
            var manufacturer = _manufacturerRepository.GetById(id);

            if (manufacturer == null)
            {
                _logger.LogInformation("Manufacturer with ID {id} not found", id);
                return NotFound();
            }

            return manufacturer;
        }

        [HttpPost]
        public IActionResult Add([FromBody] ManufacturerEntity manufacturer)
        {
            if (manufacturer == null)
            {
                return BadRequest("The manufacturer object is null");
            }

            try
            {
                // Insert the manufacturer into the database
                var addedManufacturerId = _manufacturerRepository.Create(manufacturer);
                _logger.LogInformation("Manufacturer with ID {id} created", addedManufacturerId);
                return Ok(addedManufacturerId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error inserting the manufacturer");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error inserting the manufacturer: {ex.Message}");
            }
        }


        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] ManufacturerEntity manufacturer)
        {
            if (manufacturer == null)
            {
                return BadRequest();
            }

            var existingManufacturer = _manufacturerRepository.GetById(id);

            if (existingManufacturer == null)
            {
                _logger.LogInformation("Manufacturer with ID {id} not found", id);
                return NotFound();
            }

            existingManufacturer.Name = manufacturer.Name;
            existingManufacturer.Description = manufacturer.Description;
            existingManufacturer.Logo = manufacturer.Logo;
            existingManufacturer.CountryOfOrigin = manufacturer.CountryOfOrigin;

            _manufacturerRepository.Update(existingManufacturer);
            _logger.LogInformation("Manufacturer with ID {id} updated", id);
            return Ok(existingManufacturer);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var existingManufacturer = _manufacturerRepository.GetById(id);

            if (existingManufacturer == null)
            {
                _logger.LogInformation("Manufacturer with ID {id} not found", id);
                return NotFound();
            }

            _manufacturerRepository.Delete(id);
            _logger.LogInformation("Manufacturer with ID {id} deleted", id);
            return Ok(existingManufacturer);
        }
    }
}
