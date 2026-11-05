using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Premios.Commands;

public record DeletePremioCommand(int Id) : IRequest<Unit>;

internal sealed class DeletePremioCommandHandler : IRequestHandler<DeletePremioCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeletePremioCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeletePremioCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Premio>();

        var premio = await repo.GetByIdAsync(request.Id);

        repo.Delete(premio!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
