using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Niveles.Commands;

public record DeleteNivelCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteNivelCommandHandler : IRequestHandler<DeleteNivelCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteNivelCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteNivelCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Nivele>();

        var item = await repo.GetByIdAsync(request.Id);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
