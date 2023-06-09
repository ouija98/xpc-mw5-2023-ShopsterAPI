﻿using AutoMapper;
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
    public class ManufacturerController : ControllerBase
    {
        private readonly ILogger<ManufacturerController> _logger;
        private readonly IRepository<ManufacturerEntity> _manufacturerRepository;
        private readonly IMapper _mapper;

        public ManufacturerController(ILogger<ManufacturerController> logger,
            IRepository<ManufacturerEntity> manufacturerRepository, IMapper mapper)
        {
            _logger = logger;
            _manufacturerRepository = manufacturerRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get(int page = 1, int size = 10)
        {
            try
            {
                int skip = (page - 1) * size;
                
                _logger.LogInformation("Getting all manufacturers");
                var manufacturers = _manufacturerRepository.Get().Skip(skip).Take(size);
                _logger.LogInformation($"Retrieved {manufacturers.Count()} manufacturers.");
                var manufacturerDTOs = _mapper.Map<IEnumerable<ManufacturerDTO>>(manufacturers);
                return Ok(manufacturerDTOs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving manufacturers.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving manufacturers. Please try again later.");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            _logger.LogInformation("Retrieving manufacturer by ID {id}", id);
            var manufacturer = _manufacturerRepository.GetById(id);

            if (manufacturer == null)
            {
                _logger.LogInformation("Manufacturer with ID {id} not found", id);
                return NotFound();
            }

            var manufacturerDto = _mapper.Map<ManufacturerDTO>(manufacturer);
            return Ok(manufacturerDto);
        }

        [HttpPost]
        public IActionResult Add([FromBody] ManufacturerDTO manufacturerDto)
        {
            if (manufacturerDto == null)
            {
                return BadRequest("The manufacturer object is null");
            }

            try
            {
                var manufacturer = _mapper.Map<ManufacturerEntity>(manufacturerDto);

                // Insert the manufacturer into the database
                var addedManufacturerId = _manufacturerRepository.Create(manufacturer);
                _logger.LogInformation("Manufacturer with ID {id} created", addedManufacturerId);
                return Ok(addedManufacturerId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error inserting the manufacturer");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error inserting the manufacturer!");
            }
        }

        
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] ManufacturerDTO manufacturerDTO)
        {
            if (manufacturerDTO == null || manufacturerDTO.Id != id)
            {
                return BadRequest();
            }

            var existingManufacturer = _manufacturerRepository.GetById(id);

            if (existingManufacturer == null)
            {
                _logger.LogInformation("Manufacturer with ID {id} not found", id);
                return NotFound();
            }

            try
            {
                _mapper.Map(manufacturerDTO, existingManufacturer);

                _manufacturerRepository.Update(existingManufacturer);
                _logger.LogInformation("Manufacturer with ID {id} updated", id);
                return Ok(_mapper.Map<ManufacturerDTO>(existingManufacturer));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating the manufacturer");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error updating the manufacturer!");
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var existingManufacturer = _manufacturerRepository.GetById(id);

            if (existingManufacturer == null)
            {
                _logger.LogInformation("Manufacturer with ID {id} not found", id);
                return NotFound();
            }

            _manufacturerRepository.Delete(id);
            _logger.LogInformation("Manufacturer with ID {id} deleted", id);
            return Ok(_mapper.Map<ManufacturerDTO>(existingManufacturer));
        }
        
    }
}
