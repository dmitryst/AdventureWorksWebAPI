using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventureWorksWebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AdventureWorksWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [Produces("application/json")]
        [HttpGet("/restapi/v1/TestScalarFunction/{id}")]
        public async Task<IActionResult> TestScalarFunction(int id)
        {
            var persons = await _personService.TestScalarFunction(id);
            return NewtonJson(id);
        }

        private ContentResult NewtonJson(object data)
        {
            var serializerSettings = new JsonSerializerSettings();
            return Content(JsonConvert.SerializeObject(data, Formatting.None, serializerSettings),
                "application/json");
        }
    }
}