using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.TiposAusencia.Commands;

public record UpdateTipoAusenciaCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public bool Remunerada { get; set; }
    public int? DiasMaximos { get; set; }
}

internal sealed class UpdateTipoAusenciaCommandHandler : IRequestHandler<UpdateTipoAusenciaCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateTipoAusenciaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateTipoAusenciaCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.TiposAusencium>();

        var item = await repo.GetByIdAsync(request.Id);

        item!.Nombre = request.Nombre;
        item.Remunerada = request.Remunerada;
        item.DiasMaximos = request.DiasMaximos;

        repo.Update(item);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
