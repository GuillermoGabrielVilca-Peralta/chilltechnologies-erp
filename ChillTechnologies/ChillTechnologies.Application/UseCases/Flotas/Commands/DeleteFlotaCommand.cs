using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Flotas.Commands;

public record DeleteFlotaCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteFlotaCommandHandler : IRequestHandler<DeleteFlotaCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteFlotaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteFlotaCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Flota>();

        var flota = await repo.GetByIdAsync(request.Id);

        repo.Delete(flota!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
