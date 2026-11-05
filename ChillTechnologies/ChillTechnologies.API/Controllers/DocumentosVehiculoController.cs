using MediatR;
using Microsoft.AspNetCore.Mvc;
using ChillTechnologies.Application.UseCases.DocumentosVehiculo.Commands;
using ChillTechnologies.Application.UseCases.DocumentosVehiculo.Queries;

namespace ChillTechnologies.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DocumentosVehiculoController : ControllerBase
{
    private readonly IMediator _mediator;

    public DocumentosVehiculoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _mediator.Send(new GetAllDocumentosVehiculoQuery()));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
        => Ok(await _mediator.Send(new GetDocumentoVehiculoByIdQuery(id)));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateDocumentoVehiculoCommand command)
        => Ok(await _mediator.Send(command));

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateDocumentoVehiculoCommand command)
        => Ok(await _mediator.Send(command with { Id = id }));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
        => Ok(await _mediator.Send(new DeleteDocumentoVehiculoCommand(id)));
}
