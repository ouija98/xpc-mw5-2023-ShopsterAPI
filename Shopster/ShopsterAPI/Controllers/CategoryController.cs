using Microsoft.AspNetCore.Mvc;
using Shopster.Entities;
using Shopster.Shopster.DAL.Repositories;

namespace Shopster.ShopsterAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IRepository<CategoryEntity> _categoryRepository;
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(IRepository<CategoryEntity> categoryRepository, ILogger<CategoryController> logger)
        {
            _categoryRepository = categoryRepository;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var categories = _categoryRepository.GetAll();
                _logger.LogInformation($"Retrieved {categories.Count()} categories.");
                return Ok(categories);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving categories.");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error retrieving categories: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var category = _categoryRepository.GetById(id);

                if (category == null)
                {
                    _logger.LogInformation($"Category with id {id} not found.");
                    return NotFound();
                }

                _logger.LogInformation($"Retrieved category with id {id}.");
                return Ok(category);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving category with id {id}.");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error retrieving category: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult Add([FromBody] CategoryEntity category)
        {
            if (category == null)
            {
                _logger.LogWarning("Add category request received with null category object.");
                return BadRequest("The category object is null");
            }

            try
            {
                _categoryRepository.Create(category);
 
                _logger.LogInformation($"Category with id {category.Id} created.");
                return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error inserting category with id {category.Id}.");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error inserting the category: {ex.Message}");
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] CategoryEntity category)
        {
            if (category == null)
            {
                _logger.LogWarning("Update category request received with null category object.");
                return BadRequest();
            }

            var existingCategory = _categoryRepository.GetById(category.Id);

            if (existingCategory == null)
            {
                _logger.LogInformation($"Category with id {category.Id} not found.");
                return NotFound();
            }

            existingCategory.Name = category.Name;

            try
            {
                _categoryRepository.Update(existingCategory);
                _logger.LogInformation($"Category with id {category.Id} updated.");
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating category with id {category.Id}.");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error updating the category: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var existingCategory = _categoryRepository.GetById(id);

                if (existingCategory == null)
                {
                    _logger.LogInformation($"Category with ID {id} not found.");
                    return NotFound();
                }

                _categoryRepository.Delete(id);

                _logger.LogInformation($"Category with ID {id} has been deleted successfully.");

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting category with ID {id}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error deleting the category: {ex.Message}");
            }
        }
    }
}
