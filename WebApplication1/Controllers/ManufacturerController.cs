using Bogus;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Entities;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    /// <summary>
    /// Controller for managing manufacturers.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ManufacturerController : ControllerBase
    {
        private readonly IRepository<ManufacturerEntity> _manufacturerRepository;

        /// <summary>
        /// Creates a new instance of the <see cref="ManufacturerController"/> class.
        /// </summary>
        /// <param name="manufacturerRepository">The repository for managing manufacturers.</param>
        public ManufacturerController(IRepository<ManufacturerEntity> manufacturerRepository)
        {
            _manufacturerRepository = manufacturerRepository;
        }

        /// <summary>
        /// Retrieves all manufacturers.
        /// </summary>
        /// <returns>An enumerable collection of all manufacturers.</returns>
        [HttpGet]
        public IEnumerable<ManufacturerEntity> Get()
        {
            return _manufacturerRepository.GetAll();
        }

        /// <summary>
        /// Retrieves a manufacturer by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the manufacturer to retrieve.</param>
        /// <returns>The manufacturer with the specified identifier.</returns>
        [HttpGet("{id}")]
        public ActionResult<ManufacturerEntity> GetById(Guid id)
        {
            var manufacturer = _manufacturerRepository.GetById(id);

            if (manufacturer == null)
            {
                return NotFound();
            }

            return manufacturer;
        }


        [HttpPost]
        public IActionResult AddFromBody([FromBody] ManufacturerEntity manufacturer)
        {
            if (manufacturer == null)
            {
                return BadRequest("The manufacturer object is null");
            }

            try
            {
                // Insert the manufacturer into the database
                manufacturer.Id = Guid.NewGuid();
                Database.Instance.Add(manufacturer);
                Database.Instance.SaveChanges();
                return CreatedAtAction(nameof(GetById), new { id = manufacturer.Id }, manufacturer);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error inserting the manufacturer: {ex.Message}");
            }
        }


        /// <summary>
        /// Updates a manufacturer by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the manufacturer to update.</param>
        /// <param name="manufacturer">The updated manufacturer.</param>
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
                return NotFound();
            }

            existingManufacturer.Name = manufacturer.Name;
            existingManufacturer.Description = manufacturer.Description;
            existingManufacturer.Logo = manufacturer.Logo;
            existingManufacturer.CountryOfOrigin = manufacturer.CountryOfOrigin;

            _manufacturerRepository.Update(existingManufacturer);
            return NoContent();
        }

        /// <summary>
        /// Deletes a manufacturer by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the manufacturer to delete.</param>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var existingManufacturer = _manufacturerRepository.GetById(id);
            if (existingManufacturer == null)
            {
                return NotFound();
            }

            _manufacturerRepository.Delete(id);
            return NoContent();
        }


    }
}