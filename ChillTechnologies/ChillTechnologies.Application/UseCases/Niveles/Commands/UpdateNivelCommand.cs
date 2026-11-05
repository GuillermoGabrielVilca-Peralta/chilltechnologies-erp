using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Niveles.Commands;

public record UpdateNivelCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public int PuntosMinimos { get; set; }
}

internal sealed class UpdateNivelCommandHandler : IRequestHandler<UpdateNivelCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateNivelCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateNivelCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Nivele>();

        var item = await repo.GetByIdAsync(request.Id);

        item!.Nombre = request.Nombre;
        item.PuntosMinimos = request.PuntosMinimos;

        repo.Update(item);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
