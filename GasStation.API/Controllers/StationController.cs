using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GasStation.Domain.Input;
using GasStation.Domain.Interfaces.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GasStation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StationController : ControllerBase
    {
        private readonly IStationDomainService _stationDomainService;
        public StationController(
            IStationDomainService stationDomainService
        )
        {
            _stationDomainService = stationDomainService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Post([FromBody] StationInput input)
        {
            var station = await _stationDomainService
                                    .InsertAsync(input)
                                    .ConfigureAwait(false);

            return Created("", station);
        }
    }
}
