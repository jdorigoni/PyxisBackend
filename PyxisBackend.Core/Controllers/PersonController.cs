using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PyxisBackend.Contracts;
using PyxisBackend.Contracts.Models;
using PyxisBackend.Entities.DTO;
using System;
using System.Collections.Generic;

namespace PyxisBackend.Core.Controllers
{
    [Route("api/person")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public PersonController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllPersons()
        {
            try
            {
                var persons = _repository.Person.GetAllPersons();
                _logger.LogInfo($"Returned all persons from database");

                var personsResult = _mapper.Map<IEnumerable<PersonDTO>>(persons);
                return Ok(personsResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllPersons action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetPersonById(long id)
        {
            try
            {
                var person = _repository.Person.GetPersonById(id);

                if (person == null)
                {
                    _logger.LogError($"Person with id: {id}, hasn't been found in database.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned person with id: {id}");

                    var personResult = _mapper.Map<PersonDTO>(person);
                    return Ok(personResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetPersonById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/pet")]
        public IActionResult GetPersonWithDetails(long personId)
        {
            try
            {
                var person = _repository.Person.GetPersonWithDetails(personId);

                if (person == null)
                {
                    _logger.LogError($"Person with id: {personId}, hasn't been found in database.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned person with details for id: {personId}");

                    var personResult = _mapper.Map<PersonDTO>(person);
                    return Ok(personResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetPersonWithDetails action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

    }
}