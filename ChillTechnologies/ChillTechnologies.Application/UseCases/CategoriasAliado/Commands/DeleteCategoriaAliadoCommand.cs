using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.CategoriasAliado.Commands;

public record DeleteCategoriaAliadoCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteCategoriaAliadoCommandHandler : IRequestHandler<DeleteCategoriaAliadoCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCategoriaAliadoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteCategoriaAliadoCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.CategoriasAliado>();

        var item = await repo.GetByIdAsync(request.Id);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
