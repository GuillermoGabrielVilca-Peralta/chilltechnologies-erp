using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Canjes.Commands;

public record DeleteCanjeCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteCanjeCommandHandler : IRequestHandler<DeleteCanjeCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCanjeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteCanjeCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Canje>();

        var canje = await repo.GetByIdAsync(request.Id);

        repo.Delete(canje!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
