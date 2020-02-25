using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PyxisBackend.Contracts;
using PyxisBackend.Contracts.Models;

namespace PyxisBackend.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PingController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IRepositoryWrapperPersonPet _repoWrapper;

        public PingController(ILoggerManager logger, IRepositoryWrapperPersonPet repoWrapper)
        {
            _logger = logger;
            _repoWrapper = repoWrapper;
        }

        // GET: api/Ping
        [HttpGet]
        public Ping Get()
        {
            _logger.LogInfo("Here is info message from the controller.");
            _logger.LogDebug("Here is debug message from the controller.");
            _logger.LogWarn("Here is warn message from the controller.");
            _logger.LogError("Here is error message from the controller.");

            var dogs = _repoWrapper.Pet.FindByCondition(x => x.AnimalType.Equals("Dog"));
            var persons = _repoWrapper.Person.FindAll();

            var ping = new Ping("ping");
            return ping;
        }

        // GET: api/Ping/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "valueId";
        }

        // POST: api/Ping
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Ping/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    public class Ping
    {
        public string Response { get; set; }
        public Ping(string response)
        {
            Response = response;
        }
    }
}
