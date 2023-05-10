using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shopster.DAL.Entities;
using Shopster.DAL.Repositories;
using Shopster.DAL.Repositories.Interfaces;
using Shopster.DTOs;

namespace Shopster.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RatingController : ControllerBase
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly ILogger<RatingController> _logger;
        private readonly IMapper _mapper;

        public RatingController(IRatingRepository ratingRepository, ILogger<RatingController> logger,
            IMapper mapper)
        {
            _ratingRepository = ratingRepository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get(int page = 1, int size = 10)
        {
            try
            {
                int skip = (page - 1) * size;
                
                _logger.LogInformation("Getting all ratings");
                var ratings = _ratingRepository.Get().Skip(skip).Take(size);;
                _logger.LogInformation($"Retrieved {ratings.Count()} ratings.");
                var ratingDTOs = _mapper.Map<IEnumerable<RatingDTO>>(ratings);
                return Ok(ratingDTOs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving ratings.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving ratings. Please try again later.");
            }
        }


        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            _logger.LogInformation($"Getting rating with id {id}");
            var rating = _ratingRepository.GetById(id);
            
            if (rating == null)
            {
                _logger.LogWarning($"Rating with id {id} not found");
                return NotFound();
            }

            var ratingDto = _mapper.Map<RatingDTO>(rating);
            return Ok(ratingDto);
        }

        [HttpPost]
        public IActionResult Add([FromBody] RatingDTO ratingDto)
        {
            if (ratingDto == null)
            {
                _logger.LogWarning("Rating object is null");
                return BadRequest("The rating object is null");
            }

            try
            {
                var rating = _mapper.Map<RatingEntity>(ratingDto);
                _logger.LogInformation($"Inserting new rating with title {rating.Title}");
                var addedRatingId = _ratingRepository.Create(rating);
                return Ok(addedRatingId);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error inserting rating: {ex.Message}");
                return StatusCode(500, "Error inserting rating");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] RatingDTO ratingDto)
        {
            if (ratingDto == null)
            {
                _logger.LogWarning("Rating object is null");
                return BadRequest();
            }

            var existingRating = _ratingRepository.GetById(id);
            if (existingRating == null)
            {
                _logger.LogWarning($"Rating with id {id} not found");
                return NotFound();
            }

            _mapper.Map(ratingDto, existingRating);
            _logger.LogInformation($"Updating rating with id {id}");
            _ratingRepository.Update(existingRating);
            return Ok(_mapper.Map<RatingDTO>(existingRating));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var existingRating = _ratingRepository.GetById(id);
            if (existingRating == null)
            {
                _logger.LogWarning($"Rating with id {id} not found");
                return NotFound();
            }

            _logger.LogInformation($"Deleting rating with id {id}");
            _ratingRepository.Delete(id);
            return Ok(_mapper.Map<RatingDTO>(existingRating));
        }
        
        [HttpGet("{commodityId}/ratings")]
        public IActionResult GetCommodityRatings(Guid commodityId)
        {
            var ratings = _ratingRepository.GetRatingsByCommodityId(commodityId);
            var ratingDtOs = _mapper.Map<IEnumerable<RatingDTO>>(ratings);

            return Ok(ratingDtOs);
        }
    }
}