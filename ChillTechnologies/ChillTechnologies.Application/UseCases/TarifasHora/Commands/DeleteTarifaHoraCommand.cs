using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.TarifasHora.Commands;

public record DeleteTarifaHoraCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteTarifaHoraCommandHandler : IRequestHandler<DeleteTarifaHoraCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteTarifaHoraCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteTarifaHoraCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.TarifasHora>();

        var item = await repo.GetByIdAsync(request.Id);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
