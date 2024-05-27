using ImageManipulation.Api.Domain.Commands;
using ImageManipulation.Api.Domain.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace ImageManipulation.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImageController : ControllerBase
    {
        public ImageController(IMediator mediator)
        {
            _mediator = mediator;
        }
        private readonly IMediator _mediator;
        private readonly ILogger<ImageController> _logger;

        [HttpPost(Name = "Image")]
        public async Task<IActionResult> Post([FromBody] ManipulationCommand request) 
        {
            try
            {
                ManipulationCommandResponse response = new ManipulationCommandResponse();
                response = await _mediator.Send(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                return BadRequest();
            }
            
        }

    }
}
