using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.SolicitudesAusencia.Commands;

public record DeleteSolicitudAusenciaCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteSolicitudAusenciaCommandHandler : IRequestHandler<DeleteSolicitudAusenciaCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteSolicitudAusenciaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteSolicitudAusenciaCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.SolicitudesAusencium>();

        var item = await repo.GetByIdAsync(request.Id);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
