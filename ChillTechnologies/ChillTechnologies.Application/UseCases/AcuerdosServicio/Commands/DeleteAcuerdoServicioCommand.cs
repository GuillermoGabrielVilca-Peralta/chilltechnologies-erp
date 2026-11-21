using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.AcuerdosServicio.Commands;

public record DeleteAcuerdoServicioCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteAcuerdoServicioCommandHandler : IRequestHandler<DeleteAcuerdoServicioCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAcuerdoServicioCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteAcuerdoServicioCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.AcuerdosServicio>();

        var item = await repo.GetByIdAsync(request.Id);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
