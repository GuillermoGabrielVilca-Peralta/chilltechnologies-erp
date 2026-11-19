using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.RolesSistema.Commands;

public record DeleteRolSistemaCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteRolSistemaCommandHandler : IRequestHandler<DeleteRolSistemaCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteRolSistemaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteRolSistemaCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.RolesSistema>();

        var item = await repo.GetByIdAsync(request.Id);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
