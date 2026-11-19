using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.EquiposProyecto.Commands;

public record UpdateEquipoProyectoCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Rol { get; set; } = null!;
    public decimal DedicacionPorcentaje { get; set; }
    public DateOnly? FechaSalida { get; set; }
}

internal sealed class UpdateEquipoProyectoCommandHandler : IRequestHandler<UpdateEquipoProyectoCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateEquipoProyectoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateEquipoProyectoCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.EquiposProyecto>();

        var item = await repo.GetByIdAsync(request.Id);

        item!.Rol = request.Rol;
        item.DedicacionPorcentaje = request.DedicacionPorcentaje;
        item.FechaSalida = request.FechaSalida;

        repo.Update(item);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
