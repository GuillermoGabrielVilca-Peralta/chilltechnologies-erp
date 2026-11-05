using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.TiposMantenimiento.Commands;

public record UpdateTipoMantenimientoCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public int? KmSugerido { get; set; }
}

internal sealed class UpdateTipoMantenimientoCommandHandler : IRequestHandler<UpdateTipoMantenimientoCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateTipoMantenimientoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateTipoMantenimientoCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.TiposMantenimiento>();

        var tipo = await repo.GetByIdAsync(request.Id);

        tipo!.Nombre = request.Nombre;
        tipo.KmSugerido = request.KmSugerido;

        repo.Update(tipo);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
