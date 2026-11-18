using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Cajas.Commands;

public record DeleteCajaCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteCajaCommandHandler : IRequestHandler<DeleteCajaCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCajaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteCajaCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Caja>();

        var item = await repo.GetByIdAsync(request.Id);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
