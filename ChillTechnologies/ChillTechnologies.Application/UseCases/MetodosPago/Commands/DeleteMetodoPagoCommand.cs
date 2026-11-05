using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.MetodosPago.Commands;

public record DeleteMetodoPagoCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteMetodoPagoCommandHandler : IRequestHandler<DeleteMetodoPagoCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteMetodoPagoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteMetodoPagoCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.MetodosPago>();

        var item = await repo.GetByIdAsync(request.Id);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
