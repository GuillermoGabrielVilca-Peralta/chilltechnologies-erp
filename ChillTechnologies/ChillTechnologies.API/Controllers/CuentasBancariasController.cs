using MediatR;
using Microsoft.AspNetCore.Mvc;
using ChillTechnologies.Application.UseCases.CuentasBancarias.Commands;
using ChillTechnologies.Application.UseCases.CuentasBancarias.Queries;

namespace ChillTechnologies.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CuentasBancariasController : ControllerBase
{
    private readonly IMediator _mediator;

    public CuentasBancariasController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _mediator.Send(new GetAllCuentasBancariasQuery()));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
        => Ok(await _mediator.Send(new GetCuentaBancariaByIdQuery(id)));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCuentaBancariaCommand command)
        => Ok(await _mediator.Send(command));

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateCuentaBancariaCommand command)
        => Ok(await _mediator.Send(command with { Id = id }));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
        => Ok(await _mediator.Send(new DeleteCuentaBancariaCommand(id)));
}
