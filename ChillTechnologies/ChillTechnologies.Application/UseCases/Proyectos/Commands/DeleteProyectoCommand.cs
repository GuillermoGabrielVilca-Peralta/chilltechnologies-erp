using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Proyectos.Commands;

public record DeleteProyectoCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteProyectoCommandHandler : IRequestHandler<DeleteProyectoCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProyectoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteProyectoCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Proyecto>();

        var item = await repo.GetByIdAsync(request.Id);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
