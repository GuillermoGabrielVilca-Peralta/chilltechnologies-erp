using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.EquiposProyecto.Commands;

public record DeleteEquipoProyectoCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteEquipoProyectoCommandHandler : IRequestHandler<DeleteEquipoProyectoCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteEquipoProyectoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteEquipoProyectoCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.EquiposProyecto>();

        var item = await repo.GetByIdAsync(request.Id);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
