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
        [HttpGet("Get all manufacturers")]
        public IEnumerable<ManufacturerEntity> Get()
        {
            return _manufacturerRepository.GetAll();
        }

        /// <summary>
        /// Retrieves a manufacturer by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the manufacturer to retrieve.</param>
        /// <returns>The manufacturer with the specified identifier.</returns>
        [HttpGet("Get a manufacturer by Id")]
        public ActionResult<ManufacturerEntity> GetById(Guid id)
        {
            var manufacturer = _manufacturerRepository.GetById(id);

            if (manufacturer == null)
            {
                return NotFound();
            }

            return manufacturer;
        }

        /// <summary>
        /// Updates a manufacturer by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the manufacturer to update.</param>
        /// <param name="manufacturer">The updated manufacturer.</param>
        [HttpPut("Update a manufacturer by Id")]
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
        [HttpDelete("Delete a manufacturer by Id")]
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

        /// <summary>
        /// Adds a randomly generated manufacturer to the collection.
        /// </summary>
        /// <returns>The added manufacturer.</returns>
        [HttpPost("Add a randomly generated manufacturer")]
        public ActionResult<ManufacturerEntity> Add()
        {
            var faker = new Faker<ManufacturerEntity>()
                .RuleFor(p => p.Id, f => f.Random.Guid())
                .RuleFor(p => p.Name, f => f.Company.CompanyName())
                .RuleFor(p => p.Description, f => f.Lorem.Sentence())
                .RuleFor(p => p.Logo, f => f.Internet.Avatar())
                .RuleFor(p => p.CountryOfOrigin, f => f.Address.Country());
            var newManufacturer = faker.Generate();
            _manufacturerRepository.Create(newManufacturer);
            return CreatedAtAction(nameof(GetById), new { id = newManufacturer.Id }, newManufacturer);
        }
    }
}