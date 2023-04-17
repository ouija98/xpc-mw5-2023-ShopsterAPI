using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shopster.Entities;
using System;
using Shopster.Shopster.DAL.Repositories;

namespace Shopster.ShopsterAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RatingController : ControllerBase
    {
        private readonly IRepository<RatingEntity> _ratingRepository;
        private readonly ILogger<RatingController> _logger;

        public RatingController(IRepository<RatingEntity> ratingRepository, ILogger<RatingController> logger)
        {
            _ratingRepository = ratingRepository;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            _logger.LogInformation("Getting all ratings");
            var ratings = _ratingRepository.GetAll();
            return Ok(ratings);
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

            return Ok(rating);
        }

        [HttpPost]
        public IActionResult Add([FromBody] RatingEntity rating)
        {
            if (rating == null)
            {
                _logger.LogWarning("Rating object is null");
                return BadRequest("The rating object is null");
            }

            try
            {
                _logger.LogInformation($"Inserting new rating with title {rating.Title}");
                rating.Id = Guid.NewGuid();
                _ratingRepository.Create(rating);
                return CreatedAtAction(nameof(GetById), new { id = rating.Id }, rating);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error inserting rating: {ex.Message}");
                return StatusCode(500, "Error inserting rating");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] RatingEntity rating)
        {
            if (rating == null)
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

            existingRating.Stars = rating.Stars;
            existingRating.Title = rating.Title;
            existingRating.Description = rating.Description;

            _logger.LogInformation($"Updating rating with id {id}");
            _ratingRepository.Update(existingRating);

            return NoContent();
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

            return NoContent();
        }
    }
}
