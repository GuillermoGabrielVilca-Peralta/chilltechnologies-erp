using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.ZonasRiesgo.Commands;

public record DeleteZonaRiesgoCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteZonaRiesgoCommandHandler : IRequestHandler<DeleteZonaRiesgoCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteZonaRiesgoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteZonaRiesgoCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.ZonasRiesgo>();

        var item = await repo.GetByIdAsync(request.Id);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
