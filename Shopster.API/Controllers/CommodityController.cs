using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Shopster.DAL.Entities;
using Shopster.DAL.Repositories;
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
        public IActionResult GetAll()
        {
            try
            {
                _logger.LogInformation("Getting all commodities");
                var commodities = _commodityRepository.GetAll();
                _logger.LogInformation($"Retrieved {commodities.Count()} commodities.");
                var commodityDtOs = _mapper.Map<IEnumerable<CommodityDTO>>(commodities);
                return Ok(commodityDtOs);
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
            [FromQuery] int? minRating)
        {
            _logger.LogInformation("Performing search with the following criteria: Name={Name}, MinPrice={MinPrice}, MaxPrice={MaxPrice}, CategoryId={CategoryId}, MinRating={MinRating}",
                name, minPrice, maxPrice, categoryId, minRating);

            var commodities = _commodityRepository.Search(name, minPrice, maxPrice, categoryId, minRating);
            var commodityDtos = _mapper.Map<IEnumerable<CommodityDTO>>(commodities);

            return Ok(commodityDtos);
        }
    }
}