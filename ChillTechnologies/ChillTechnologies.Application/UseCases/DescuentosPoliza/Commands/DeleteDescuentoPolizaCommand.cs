using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.DescuentosPoliza.Commands;

public record DeleteDescuentoPolizaCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteDescuentoPolizaCommandHandler : IRequestHandler<DeleteDescuentoPolizaCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteDescuentoPolizaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteDescuentoPolizaCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.DescuentosPoliza>();

        var item = await repo.GetByIdAsync(request.Id);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
