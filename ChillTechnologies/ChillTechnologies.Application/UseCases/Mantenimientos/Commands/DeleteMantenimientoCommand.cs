using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Mantenimientos.Commands;

public record DeleteMantenimientoCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteMantenimientoCommandHandler : IRequestHandler<DeleteMantenimientoCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteMantenimientoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteMantenimientoCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Mantenimiento>();

        var mantenimiento = await repo.GetByIdAsync(request.Id);

        repo.Delete(mantenimiento!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
