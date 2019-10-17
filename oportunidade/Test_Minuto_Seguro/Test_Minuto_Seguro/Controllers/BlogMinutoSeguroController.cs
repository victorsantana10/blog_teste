using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Test_Minuto_Seguro.Services;

namespace Test_Minuto_Seguro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogMinutoSeguroController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(Exception), (int)HttpStatusCode.InternalServerError)]
        public IActionResult Get()
        {
            try
            {
                var xml = ReadXml.GetObjectByXml();
                var format = new FormatDataXml();
                return Ok(format.GetWordsHighestRelevanceByPostAndTotal(xml));
            }
            catch (Exception e)
            {
                return StatusCode(500, new Exception(e.Message));
            }
        }
    }
}
