using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.TiposProyecto.Commands;

public record DeleteTipoProyectoCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteTipoProyectoCommandHandler : IRequestHandler<DeleteTipoProyectoCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteTipoProyectoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteTipoProyectoCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.TiposProyecto>();

        var item = await repo.GetByIdAsync(request.Id);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
