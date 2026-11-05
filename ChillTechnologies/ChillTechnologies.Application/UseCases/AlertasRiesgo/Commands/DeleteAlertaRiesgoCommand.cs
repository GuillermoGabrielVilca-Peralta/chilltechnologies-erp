using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.AlertasRiesgo.Commands;

public record DeleteAlertaRiesgoCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteAlertaRiesgoCommandHandler : IRequestHandler<DeleteAlertaRiesgoCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAlertaRiesgoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteAlertaRiesgoCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.AlertasRiesgo>();

        var alerta = await repo.GetByIdAsync(request.Id);

        repo.Delete(alerta!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
