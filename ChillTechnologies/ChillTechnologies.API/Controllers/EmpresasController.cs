using MediatR;
using Microsoft.AspNetCore.Mvc;
using ChillTechnologies.Application.UseCases.Empresas.Commands;
using ChillTechnologies.Application.UseCases.Empresas.Queries;

namespace ChillTechnologies.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmpresasController : ControllerBase
{
    private readonly IMediator _mediator;

    public EmpresasController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _mediator.Send(new GetAllEmpresasQuery()));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
        => Ok(await _mediator.Send(new GetEmpresaByIdQuery(id)));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateEmpresaCommand command)
        => Ok(await _mediator.Send(command));

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateEmpresaCommand command)
        => Ok(await _mediator.Send(command with { Id = id }));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
        => Ok(await _mediator.Send(new DeleteEmpresaCommand(id)));
}
