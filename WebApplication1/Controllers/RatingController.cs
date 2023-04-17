using Bogus;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Entities;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    /// <summary>
    /// A controller for managing ratings.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class RatingController : ControllerBase
    {
        private readonly IRepository<RatingEntity> _ratingRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="RatingController"/> class.
        /// </summary>
        /// <param name="ratingRepository">The rating repository.</param>
        public RatingController(IRepository<RatingEntity> ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }

        /// <summary>
        /// Retrieves all the ratings.
        /// </summary>
        /// <returns>The list of all the ratings.</returns>
        [HttpGet]
        public IEnumerable<RatingEntity> GetAll()
        {
            return _ratingRepository.GetAll();
        }

        /// <summary>
        /// Retrieves a rating by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the rating to retrieve.</param>
        /// <returns>The rating with the specified identifier.</returns>
        [HttpGet("{id}")]
        public ActionResult<RatingEntity> GetById(Guid id)
        {
            var rating = _ratingRepository.GetById(id);

            if (rating == null)
            {
                return NotFound();
            }

            return rating;
        }


        [HttpPost]
        public IActionResult AddFromBody([FromBody] RatingEntity rating)
        {
            if (rating == null)
            {
                return BadRequest("The rating object is null");
            }

            try
            {
                // Insert the rating into the database
                rating.Id = Guid.NewGuid();
                Database.Instance.Add(rating);
                Database.Instance.SaveChanges();
                return CreatedAtAction(nameof(GetById), new { id = rating.Id }, rating);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error inserting the rating: {ex.Message}");
            }
        }


        /// <summary>
        /// Updates a rating by its identifier.
        /// </summary>
        /// <param name="rating">The rating to update.</param>
        /// <returns>No content.</returns>
        [HttpPut("{id}")]
        public IActionResult Update([FromBody] RatingEntity rating)
        {
            if (rating == null)
            {
                return BadRequest();
            }

            var existingRating = _ratingRepository.GetById(rating.Id);

            if (existingRating == null)
            {
                return NotFound();
            }

            existingRating.Stars = rating.Stars;
            existingRating.Title = rating.Title;
            existingRating.Description = rating.Description;

            _ratingRepository.Update(existingRating);

            return NoContent();
        }

        /// <summary>
        /// Deletes a rating by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the rating to delete.</param>
        /// <returns>No content.</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            //TODO TRY
            var existingRating = _ratingRepository.GetById(id);

            if (existingRating == null)
            {
                return NotFound();
            }

            _ratingRepository.Delete(id);

            return NoContent();
        }


    }
}