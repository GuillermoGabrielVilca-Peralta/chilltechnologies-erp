using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Tareas.Commands;

public record DeleteTareaCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteTareaCommandHandler : IRequestHandler<DeleteTareaCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteTareaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteTareaCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Tarea>();

        var item = await repo.GetByIdAsync(request.Id);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
