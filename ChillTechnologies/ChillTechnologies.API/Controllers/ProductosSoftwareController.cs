using MediatR;
using Microsoft.AspNetCore.Mvc;
using ChillTechnologies.Application.UseCases.ProductosSoftware.Commands;
using ChillTechnologies.Application.UseCases.ProductosSoftware.Queries;

namespace ChillTechnologies.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductosSoftwareController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductosSoftwareController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _mediator.Send(new GetAllProductosSoftwareQuery()));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
        => Ok(await _mediator.Send(new GetProductoSoftwareByIdQuery(id)));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductoSoftwareCommand command)
        => Ok(await _mediator.Send(command));

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateProductoSoftwareCommand command)
        => Ok(await _mediator.Send(command with { Id = id }));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
        => Ok(await _mediator.Send(new DeleteProductoSoftwareCommand(id)));
}
