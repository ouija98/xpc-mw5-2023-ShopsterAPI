using Bogus;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Entities;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    /// <summary>
    /// Controller for managing categories of commodities.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IRepository<CategoryEntity> _categoryRepository;

        /// <summary>
        /// Creates a new instance of the <see cref="CategoryController"/> class.
        /// </summary>
        /// <param name="categoryRepository">The repository for managing categories.</param>
        public CategoryController(IRepository<CategoryEntity> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        /// <summary>
        /// Retrieves all categories of commodities.
        /// </summary>
        /// <returns>An enumerable collection of all categories.</returns>
        [HttpGet("Get all categories")]
        public IEnumerable<CategoryEntity> Get()
        {
            return _categoryRepository.GetAll();
        }

        /// <summary>
        /// Retrieves a category of commodities by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the category to retrieve.</param>
        /// <returns>The category with the specified identifier.</returns>
        [HttpGet("Get a category by Id")]
        public ActionResult<CategoryEntity> GetById(Guid id)
        {
            var category = _categoryRepository.GetById(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        /// <summary>
        /// Updates a category of commodities by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the category to update.</param>
        /// <param name="category">The updated category.</param>
        [HttpPut("Update a category by Id")]
        public IActionResult Update([FromBody] CategoryEntity category)
        {
            if (category == null)
            {
                return BadRequest();
            }

            var existingCategory = _categoryRepository.GetById(category.Id);

            if (existingCategory == null)
            {
                return NotFound();
            }

            existingCategory.Name = category.Name;

            _categoryRepository.Update(existingCategory);
            return NoContent();
        }

        /// <summary>
        /// Deletes a category of commodities by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the category to delete.</param>
        [HttpDelete("Delete a category by Id")]
        public IActionResult Delete(Guid id)
        {
            var existingCategory = _categoryRepository.GetById(id);

            if (existingCategory == null)
            {
                return NotFound();
            }

            _categoryRepository.Delete(id);

            return NoContent();
        }

        /// <summary>
        /// Adds a randomly generated category to the collection.
        /// </summary>
        /// <returns>The added category.</returns>
        [HttpPost("Add a randomly generated category")]
        public ActionResult<CategoryEntity> Add()
        {
            var faker = new Faker<CategoryEntity>()
                .RuleFor(p => p.Id, f => f.Random.Guid())
                .RuleFor(p => p.Name, f => f.Commerce.Categories(1)[0]);

            var newCategory = faker.Generate();

            _categoryRepository.Create(newCategory);

            return CreatedAtAction(nameof(GetById), new { id = newCategory.Id }, newCategory);
        }
    }
}