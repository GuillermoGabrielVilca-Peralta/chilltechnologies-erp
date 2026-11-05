using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Polizas.Commands;

public record DeletePolizaCommand(int Id) : IRequest<Unit>;

internal sealed class DeletePolizaCommandHandler : IRequestHandler<DeletePolizaCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeletePolizaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeletePolizaCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Poliza>();

        var item = await repo.GetByIdAsync(request.Id);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
