using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PyxisBackend.Contracts;
using PyxisBackend.Contracts.Models;
using PyxisBackend.Entities.DTO;
using System;
using System.Collections.Generic;

namespace PyxisBackend.Core.Controllers
{
    [Route("api/pet")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public PetController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllPets()
        {
            try
            {
                var pets = _repository.Pet.GetAllPets();
                _logger.LogInfo($"Returned all pets from database");

                var petsResults = _mapper.Map<IEnumerable<PetDTO>>(pets);
                return Ok(petsResults);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllPets action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetPetById(Guid id)
        {
            try
            {
                var pet = _repository.Pet.GetPetById(id);

                if (pet == null)
                {
                    _logger.LogError($"Pet with id: {id}, hasn't been found in database.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned pet with id: {id}");

                    var petResult = _mapper.Map<PetDTO>(pet);
                    return Ok(petResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetPetById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

    }
}