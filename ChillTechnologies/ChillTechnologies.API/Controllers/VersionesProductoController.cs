using MediatR;
using Microsoft.AspNetCore.Mvc;
using ChillTechnologies.Application.UseCases.VersionesProducto.Commands;
using ChillTechnologies.Application.UseCases.VersionesProducto.Queries;

namespace ChillTechnologies.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VersionesProductoController : ControllerBase
{
    private readonly IMediator _mediator;

    public VersionesProductoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _mediator.Send(new GetAllVersionesProductoQuery()));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
        => Ok(await _mediator.Send(new GetVersionProductoByIdQuery(id)));

    [HttpGet("producto/{productoSoftwareId:int}")]
    public async Task<IActionResult> GetByProducto(int productoSoftwareId)
        => Ok(await _mediator.Send(new GetVersionesByProductoQuery(productoSoftwareId)));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateVersionProductoCommand command)
        => Ok(await _mediator.Send(command));

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateVersionProductoCommand command)
        => Ok(await _mediator.Send(command with { Id = id }));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
        => Ok(await _mediator.Send(new DeleteVersionProductoCommand(id)));
}
