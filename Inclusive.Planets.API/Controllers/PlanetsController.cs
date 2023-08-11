using Inclusive.Planets.Core.CQRS.Commands;
using Inclusive.Planets.Core.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Inclusive.Planets.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanetsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;
        public PlanetsController(IMediator mediator, ILogger<PlanetsController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [Route("planets")]
        [HttpGet]
        public async Task<IActionResult> GetPlanets()
        {
            var planets = await _mediator.Send(new GetPlanets()).ConfigureAwait(false);
            return Ok(planets);
        }

        [Route("planet/{planetName}")]
        [HttpGet]
        public async Task<IActionResult> GetPlanet(string planetName)
        {
            var planet = await _mediator.Send(new GetPlanet(planetName)).ConfigureAwait(false);
            return Ok(planet);
        }

        [Route("upload")]
        [HttpPost]
        public async Task<IActionResult> UploadPlanetsImages()
        {
            var isImagesUploaded = await _mediator.Send(new UploadPlanetsImages()).ConfigureAwait(false);
            return Ok(isImagesUploaded);
        }
    }
}
