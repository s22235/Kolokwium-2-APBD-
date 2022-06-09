using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Service;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/Musical")]
    public class MusicalController : ControllerBase
    {
        private readonly IDbService _dbservice;
        public MusicalController(IDbService _service)
        {
            _dbservice = _service;
        }

        [HttpGet]
        [Route("{idMusician}")]
        public async Task<IActionResult> GetMusician(int idMusician)
        {
            var getMusician = await _dbservice.GetMusician(idMusician);
            if (getMusician is null)
                return BadRequest("There is no sucj musician");
            else
                return Ok(getMusician);
        }

        [HttpDelete]
        [Route("{idMusician}")]
        public async Task<IActionResult> DeleteClient(int idMusician)
        {
            var result = await _dbservice.RemoveMusician(idMusician);
            if (result.Contains("Error"))
                return BadRequest(result);
            else
                return Ok(result);
        }

    }
}
