using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Shopster.DAL.Entities;
using Shopster.DAL.Repositories;
using Shopster.DAL.Repositories.Interfaces;
using Shopster.DTOs;

namespace Shopster.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IRepository<CategoryEntity> _categoryRepository;
        private readonly ILogger<CategoryController> _logger;
        private readonly IMapper _mapper;

        public CategoryController(IRepository<CategoryEntity> categoryRepository, ILogger<CategoryController> logger,
            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get(int page = 1, int size = 10)
        {
            
            try
            {
                // Calculate the number of items to skip
                int skip = (page - 1) * size;
                
                _logger.LogInformation("Getting all categories");
                var categories = _categoryRepository.Get().Skip(skip).Take(size);
                _logger.LogInformation($"Retrieved {categories.Count()} categories.");
                var categoriesDto = _mapper.Map<IEnumerable<CategoryDTO>>(categories);
                return Ok(categoriesDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving categories.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving categories. Please try again later.");
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

                var categoryDTO = _mapper.Map<CategoryDTO>(category);
                _logger.LogInformation($"Retrieved category with id {id}.");
                return Ok(categoryDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving category with id {id}.");
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving category: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult Add([FromBody] CategoryDTO categoryDTO)
        {
            if (categoryDTO == null)
            {
                _logger.LogWarning("Add category request received with null category object.");
                return BadRequest("The category object is null");
            }

            try
            {
                var category = _mapper.Map<CategoryEntity>(categoryDTO);
                _categoryRepository.Create(category);

                _logger.LogInformation($"Category with id {category.Id} created.");
                return Ok(category);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error inserting category with id {categoryDTO.Id}.");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error inserting the category.");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] CategoryDTO categoryDTO)
        {
            if (categoryDTO == null)
            {
                _logger.LogWarning("Update category request received with null category object.");
                return BadRequest();
            }

            var existingCategory = _categoryRepository.GetById(id);
            if (existingCategory == null)
            {
                _logger.LogWarning($"Category with id {id} not found");
                return NotFound();
            }

            try
            {
                var updatedCategory = _mapper.Map<CategoryEntity>(categoryDTO);
                updatedCategory.Id = id;

                _categoryRepository.Update(updatedCategory);

                _logger.LogInformation($"Category with id {id} updated.");
                return Ok(updatedCategory);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating category with id {id}.");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error updating the category.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var existingCategory = _categoryRepository.GetById(id);
            if (existingCategory == null)
            {
                _logger.LogWarning($"Category with id {id} not found");
                return NotFound();
            }

            try
            {
                _categoryRepository.Delete(id);

                _logger.LogInformation($"Category with id {id} deleted.");
                return Ok(existingCategory);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting category with id {id}.");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error deleting the category!");
            }
        }
    }
}