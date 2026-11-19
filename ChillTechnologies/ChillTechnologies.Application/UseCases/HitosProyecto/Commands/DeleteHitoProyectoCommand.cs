using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.HitosProyecto.Commands;

public record DeleteHitoProyectoCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteHitoProyectoCommandHandler : IRequestHandler<DeleteHitoProyectoCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteHitoProyectoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteHitoProyectoCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.HitosProyecto>();

        var item = await repo.GetByIdAsync(request.Id);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
