using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnTime.Module.Logic.Commands.Project;
using OnTime.Module.Logic.Queries;
using OnTime.Module.Logic.Queries.Project;
using OnTime.ResponseHandler.Models;


namespace ProjectPulse.Logic.API.Controllers
{
 
        [Route("api/[controller]")]
        [ApiController]
        public class ProductsController : ApiControllerBase
        {
            private readonly IMediator _mediator;

            public ProductsController(IMediator mediator)
            {
                _mediator = mediator;
            }
        [Authorize]
        [HttpGet("{id}")]
            public async Task<IActionResult> GetProductById(Guid id)
            {
                var query = new GetProductByIdQuery(id);
                var result = await _mediator.Send(query);
                return ProcessResponse(result);
            }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand command)
        {
            var result = await _mediator.Send(command);
            return ProcessResponse(result);
        }

    }
}


