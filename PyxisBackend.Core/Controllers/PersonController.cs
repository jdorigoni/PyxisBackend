﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PyxisBackend.Contracts;
using PyxisBackend.Contracts.Models;
using PyxisBackend.Entities.DTO;
using PyxisBackend.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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

        [HttpGet("{id}", Name = "PersonById")]
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

        [HttpGet("{id}/person")]
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

        [HttpPost]
        public IActionResult CreatePerson([FromBody]PersonForCreateUpdateDTO person)
        {
            try
            {
                if (person == null)
                {
                    _logger.LogError("Person object sent from client is null.");
                    return BadRequest("Person object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid person object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var personEntity = _mapper.Map<Person>(person);

                _repository.Person.CreatePerson(personEntity);
                _repository.Save();

                var createdPerson = _mapper.Map<PersonDTO>(personEntity);

                return CreatedAtRoute("PersonById", new { id = createdPerson.Id }, createdPerson);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreatePerson action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPut("{id}")]
        public IActionResult UpdatePerson(long id, [FromBody]PersonForCreateUpdateDTO person)
        {
            try
            {
                if (person == null)
                {
                    _logger.LogError("Person object sent from client is null.");
                    return BadRequest("Person object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid person object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var personEntity = _repository.Person.GetPersonById(id);
                if (personEntity == null)
                {
                    _logger.LogError($"Person with id: {id}, hasn't been found in database.");
                    return NotFound();
                }

                _mapper.Map(person, personEntity);

                _repository.Person.UpdatePerson(personEntity);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdatePerson action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePerson(long id)
        {
            try
            {
                var person = _repository.Person.GetPersonById(id);
                if (person == null)
                {
                    _logger.LogError($"Person with id: {id}, hasn't been found in database.");
                    return NotFound();
                }
                if (_repository.Pet.PetsByPerson(id).Any())
                {
                    _logger.LogError($"Cannot delete person with id: {id}. It has related pets. Delete those pets first");
                    return BadRequest("Cannot delete person. It has related pets. Delete those pets first");
                }

                _repository.Person.DeletePerson(person);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeletePerson action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}