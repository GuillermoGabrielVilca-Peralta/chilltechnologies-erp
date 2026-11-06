using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Empleados.Commands;

public record DeleteEmpleadoCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteEmpleadoCommandHandler : IRequestHandler<DeleteEmpleadoCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteEmpleadoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteEmpleadoCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Empleado>();

        var item = await repo.GetByIdAsync(request.Id);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
