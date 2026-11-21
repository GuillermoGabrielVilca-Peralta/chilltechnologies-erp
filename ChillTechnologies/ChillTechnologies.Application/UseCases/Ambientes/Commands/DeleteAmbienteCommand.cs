using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Ambientes.Commands;

public record DeleteAmbienteCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteAmbienteCommandHandler : IRequestHandler<DeleteAmbienteCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAmbienteCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteAmbienteCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Ambiente>();

        var item = await repo.GetByIdAsync(request.Id);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
