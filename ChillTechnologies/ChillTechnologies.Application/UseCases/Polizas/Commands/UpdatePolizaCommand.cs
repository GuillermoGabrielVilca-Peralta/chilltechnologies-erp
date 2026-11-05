using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Polizas.Commands;

public record UpdatePolizaCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Numero { get; set; } = null!;
    public DateOnly FechaInicio { get; set; }
    public DateOnly FechaFin { get; set; }
    public decimal PrimaSoles { get; set; }
    public string? Cobertura { get; set; }
    // Vigente, Vencida o Cancelada
    public string Estado { get; set; } = null!;
}

internal sealed class UpdatePolizaCommandHandler : IRequestHandler<UpdatePolizaCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePolizaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdatePolizaCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Poliza>();

        var item = await repo.GetByIdAsync(request.Id);

        item!.Numero = request.Numero;
        item.FechaInicio = request.FechaInicio;
        item.FechaFin = request.FechaFin;
        item.PrimaSoles = request.PrimaSoles;
        item.Cobertura = request.Cobertura;
        item.Estado = request.Estado;

        repo.Update(item);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
