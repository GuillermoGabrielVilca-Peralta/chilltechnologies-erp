using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.ModelosIa.Commands;

public record DeleteModeloIaCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteModeloIaCommandHandler : IRequestHandler<DeleteModeloIaCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteModeloIaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteModeloIaCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.ModelosIum>();

        var item = await repo.GetByIdAsync(request.Id);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
