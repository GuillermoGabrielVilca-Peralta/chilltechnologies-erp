using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.UmbralesDeteccion.Commands;

public record UpdateUmbralDeteccionCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public int TipoEventoId { get; set; }
    public decimal ConfianzaMinima { get; set; }
}

internal sealed class UpdateUmbralDeteccionCommandHandler : IRequestHandler<UpdateUmbralDeteccionCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateUmbralDeteccionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateUmbralDeteccionCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.UmbralesDeteccion>();

        var item = await repo.GetByIdAsync(request.Id);

        item!.TipoEventoId = request.TipoEventoId;
        item.ConfianzaMinima = request.ConfianzaMinima;

        repo.Update(item);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
