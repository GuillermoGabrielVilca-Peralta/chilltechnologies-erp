using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.UmbralesDeteccion.Commands;

public record DeleteUmbralDeteccionCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteUmbralDeteccionCommandHandler : IRequestHandler<DeleteUmbralDeteccionCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteUmbralDeteccionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteUmbralDeteccionCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.UmbralesDeteccion>();

        var item = await repo.GetByIdAsync(request.Id);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
