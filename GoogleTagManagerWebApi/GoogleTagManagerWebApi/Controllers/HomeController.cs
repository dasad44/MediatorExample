using GoogleTagManagerWebApp.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GoogleTagManagerWebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> GoogleTagManagerRequest([FromBody]GoogleTagManagerCommand googleTagManagerCommand)
        {
            var result = await _mediator.Send(googleTagManagerCommand);
            return Ok(result);
        }
    }
}
