using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IMapper _mapper;

        public CommodityController(ILogger<CommodityController> logger,
            IRepository<CommodityEntity> commodityRepository, IMapper mapper)
        {
            _logger = logger;
            _commodityRepository = commodityRepository;
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
    }
}