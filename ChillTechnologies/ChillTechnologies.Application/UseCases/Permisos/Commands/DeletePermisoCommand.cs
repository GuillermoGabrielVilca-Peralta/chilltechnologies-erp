using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Permisos.Commands;

public record DeletePermisoCommand(int Id) : IRequest<Unit>;

internal sealed class DeletePermisoCommandHandler : IRequestHandler<DeletePermisoCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeletePermisoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeletePermisoCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Permiso>();

        var item = await repo.GetByIdAsync(request.Id);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
