using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Aliados.Commands;

public record DeleteAliadoCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteAliadoCommandHandler : IRequestHandler<DeleteAliadoCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAliadoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteAliadoCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Aliado>();

        var aliado = await repo.GetByIdAsync(request.Id);

        repo.Delete(aliado!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
