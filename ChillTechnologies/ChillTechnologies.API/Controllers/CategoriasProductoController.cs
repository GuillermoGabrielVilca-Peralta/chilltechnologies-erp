using MediatR;
using Microsoft.AspNetCore.Mvc;
using ChillTechnologies.Application.UseCases.CategoriasProducto.Commands;
using ChillTechnologies.Application.UseCases.CategoriasProducto.Queries;

namespace ChillTechnologies.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriasProductoController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoriasProductoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _mediator.Send(new GetAllCategoriasProductoQuery()));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
        => Ok(await _mediator.Send(new GetCategoriaProductoByIdQuery(id)));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCategoriaProductoCommand command)
        => Ok(await _mediator.Send(command));

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateCategoriaProductoCommand command)
        => Ok(await _mediator.Send(command with { Id = id }));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
        => Ok(await _mediator.Send(new DeleteCategoriaProductoCommand(id)));
}
