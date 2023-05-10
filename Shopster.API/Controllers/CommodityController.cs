using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shopster.DAL.Entities;
using Shopster.DAL.Repositories.Interfaces;
using Shopster.DTOs;

namespace Shopster.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommodityController : ControllerBase
    {
        private readonly ILogger<CommodityController> _logger;
        private readonly ICommodityRepository _commodityRepository;
        private readonly IMapper _mapper;

        public CommodityController(ILogger<CommodityController> logger,
            ICommodityRepository commodityRepository, IMapper mapper)
        {
            _logger = logger;
            _commodityRepository = commodityRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get(int page = 1, int size = 10)
        {
            try
            {
                int skip = (page - 1) * size;
                
                _logger.LogInformation("Getting all commodities");
                var commodities = _commodityRepository.Get().Skip(skip).Take(size);;
                _logger.LogInformation($"Retrieved {commodities.Count()} commodities.");
                var commodityDTOs = _mapper.Map<IEnumerable<CommodityDTO>>(commodities);
                return Ok(commodityDTOs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving commodities.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving commodities. Please try again later.");
            }
        }


        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            _logger.LogInformation($"Getting commodity with id {id}");
            var commodity = _commodityRepository.GetById(id);

            if (commodity == null)
            {
                _logger.LogWarning($"Commodity with id {id} not found");
                return NotFound();
            }

            var commodityDto = _mapper.Map<CommodityDTO>(commodity);
            return Ok(commodityDto);
        }

        [HttpPost]
        public IActionResult Add([FromBody] CommodityDTO commodityDto)
        {
            try
            {
                var commodity = _mapper.Map<CommodityEntity>(commodityDto);
                _logger.LogInformation($"Inserting new commodity with name {commodity.Name}");
                var addedCommodityId = _commodityRepository.Create(commodity);
                return Ok(addedCommodityId);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error inserting the commodity: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error inserting the commodity!");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] CommodityDTO commodityDto)
        {
            if (commodityDto.Id != id)
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

            try
            {
                _mapper.Map(commodityDto, existingCommodity);

                _logger.LogInformation($"Updating commodity with id {id}");
                _commodityRepository.Update(existingCommodity);

                return Ok(_mapper.Map<CommodityDTO>(existingCommodity));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating commodity with id {id}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error updating the commodity!");
            }
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

                return Ok(_mapper.Map<CommodityDTO>(existingCommodity));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting commodity with ID {id}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error deleting the commodity!");
            }
        }

        // Perform the search based on the provided criteria
        [HttpGet("search")]
        public IActionResult Search(
            [FromQuery] string? name,
            [FromQuery] decimal? minPrice,
            [FromQuery] decimal? maxPrice,
            [FromQuery] Guid? categoryId,
            [FromQuery] int? minRating,
            [FromQuery] string? manufacturerFilter, // manufacturer name or id
            [FromQuery] string? sort = "name:asc") 
        {
            _logger.LogInformation("Performing search with the following criteria: Name={Name}, MinPrice={MinPrice}, MaxPrice={MaxPrice}, CategoryId={CategoryId}, MinRating={MinRating}, ManufacturerIdOrName={ManufacturerIdOrName}, Sort={Sort}",
                name, minPrice, maxPrice, categoryId, minRating, manufacturerFilter, sort);

            var commodities = _commodityRepository.Search(name, minPrice, maxPrice, categoryId, minRating, manufacturerFilter);
            
            if (!string.IsNullOrEmpty(sort))
            {
                commodities = _commodityRepository.Sort(commodities, sort);
            }
            
            var commodityDTOs = _mapper.Map<IEnumerable<CommodityDTO>>(commodities);

            return Ok(commodityDTOs);
        }

        [HttpGet("top-rated")]
        public IActionResult GetTopRatedCommodities(int page = 1, int size = 10)
        {
            try
            {
                int skip = (page - 1) * size;
                
                _logger.LogInformation("Retrieving top-rated commodities");

                var topRatedCommodities = _commodityRepository.GetTopRatedCommodities().Skip(skip).Take(size);
        
                if (!topRatedCommodities.Any())
                {
                    _logger.LogInformation("No commodities found");
                    return NotFound();
                }
        
                var topRatedCommoditiesDto = _mapper.Map<IEnumerable<CommodityDTO>>(topRatedCommodities);

                _logger.LogInformation("Top-rated commodities retrieved");
                return Ok(topRatedCommoditiesDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving top-rated commodities");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving the top-rated commodities. Please try again later.");
            }
        }

    }
}