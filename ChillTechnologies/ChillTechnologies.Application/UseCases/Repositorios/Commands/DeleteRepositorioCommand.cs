using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Repositorios.Commands;

public record DeleteRepositorioCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteRepositorioCommandHandler : IRequestHandler<DeleteRepositorioCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteRepositorioCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteRepositorioCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Repositorio>();

        var item = await repo.GetByIdAsync(request.Id);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
