using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.TiposEvento.Commands;

public record UpdateTipoEventoCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public int ImpactoPuntajeDefault { get; set; }
}

internal sealed class UpdateTipoEventoCommandHandler : IRequestHandler<UpdateTipoEventoCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateTipoEventoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateTipoEventoCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.TiposEvento>();

        var item = await repo.GetByIdAsync(request.Id);

        item!.Nombre = request.Nombre;
        item.ImpactoPuntajeDefault = request.ImpactoPuntajeDefault;

        repo.Update(item);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
