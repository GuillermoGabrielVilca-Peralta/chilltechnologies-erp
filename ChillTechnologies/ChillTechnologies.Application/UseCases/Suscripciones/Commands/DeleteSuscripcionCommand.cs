using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Suscripciones.Commands;

public record DeleteSuscripcionCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteSuscripcionCommandHandler : IRequestHandler<DeleteSuscripcionCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteSuscripcionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteSuscripcionCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Suscripcione>();

        var suscripcion = await repo.GetByIdAsync(request.Id);

        repo.Delete(suscripcion!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
