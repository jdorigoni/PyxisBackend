using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PyxisBackend.Contracts;

namespace PyxisBackend.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PingController : ControllerBase
    {
        private readonly ILoggerManager _logger;

        public PingController(ILoggerManager logger)
        {
            _logger = logger;
        }

        // GET: api/Ping
        [HttpGet]
        public IEnumerable<string> Get()
        {
            _logger.LogInfo("Here is info message from the controller.");
            _logger.LogDebug("Here is debug message from the controller.");
            _logger.LogWarn("Here is warn message from the controller.");
            _logger.LogError("Here is error message from the controller.");
       
            var response = new List<string>();
            response.Add("ping1");
            response.Add("ping2");
            
            return response;
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
}
