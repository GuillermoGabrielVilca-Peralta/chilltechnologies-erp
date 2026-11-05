using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Flotas.Commands;

public record UpdateFlotaCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Descripcion { get; set; }
    // Activa o Inactiva
    public string Estado { get; set; } = null!;
}

internal sealed class UpdateFlotaCommandHandler : IRequestHandler<UpdateFlotaCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateFlotaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateFlotaCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Flota>();

        var flota = await repo.GetByIdAsync(request.Id);

        flota!.Nombre = request.Nombre;
        flota.Descripcion = request.Descripcion;
        flota.Estado = request.Estado;

        repo.Update(flota);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
