using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Shopster.DAL.Entities;
using Shopster.DAL.Repositories;
using Shopster.DTOs;

namespace Shopster.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommodityController : ControllerBase
    {
        private readonly ILogger<CommodityController> _logger;
        private readonly IRepository<CommodityEntity> _commodityRepository;
        private readonly IRepository<RatingEntity> _ratingRepository;
        private readonly IMapper _mapper;

        public CommodityController(ILogger<CommodityController> logger,
            IRepository<CommodityEntity> commodityRepository, IRepository<RatingEntity> ratingRepository, IMapper mapper)
        {
            _logger = logger;
            _commodityRepository = commodityRepository;
            _ratingRepository = ratingRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            _logger.LogInformation("Getting all commodities");
            var commodities = _commodityRepository.GetAll().ProjectTo<CommodityDTO>(_mapper.ConfigurationProvider);
            return Ok(commodities);
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
            if (commodityDto == null)
            {
                _logger.LogError("Commodity object is null");
                return BadRequest("The commodity object is null");
            }

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
                    $"Error inserting the commodity: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] CommodityDTO commodityDTO)
        {
            if (commodityDTO == null || commodityDTO.Id != id)
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

            _mapper.Map(commodityDTO, existingCommodity);

            _logger.LogInformation($"Updating commodity with id {id}");
            _commodityRepository.Update(existingCommodity);

            return Ok(_mapper.Map<CommodityDTO>(existingCommodity));
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
                    $"Error deleting the commodity: {ex.Message}");
            }
        }
        
        [HttpGet("{commodityId}/ratings")]
        public IActionResult GetCommodityRatings(Guid commodityId)
        {
            var commodity = _commodityRepository.GetById(commodityId);

            if (commodity == null)
            {
                _logger.LogWarning($"Commodity with id {commodityId} not found");
                return NotFound();
            }

            var ratings = _ratingRepository.GetAll(); // Get all ratings from the repository or database
            var matchingRatings = ratings.Where(r => r.CommodityEntityId == commodityId);
            var ratingDTOs = _mapper.Map<IEnumerable<RatingDTO>>(matchingRatings);

            return Ok(ratingDTOs);
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

            var commodities = _commodityRepository.GetAll();

            if (!name.IsNullOrEmpty())
            {
                commodities = commodities.Where(c => c.Name.Contains(name));
            }

            if (minPrice.HasValue)
            {
                commodities = commodities.Where(c => c.Price >= minPrice);
            }

            if (maxPrice.HasValue)
            {
                commodities = commodities.Where(c => c.Price <= maxPrice);
            }

            if (categoryId.HasValue)
            {
                commodities = commodities.Where(c => c.CategoryId == categoryId);
            }

            if (minRating.HasValue)
            {
                commodities = commodities.Where(c => c.Ratings.Any(r => r.Stars >= minRating));
            }

            return Ok(_mapper.ProjectTo<CommodityDTO>(commodities));
        }
    }
}