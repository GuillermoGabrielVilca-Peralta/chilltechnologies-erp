using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Cargos.Commands;

public record DeleteCargoCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteCargoCommandHandler : IRequestHandler<DeleteCargoCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCargoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteCargoCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Cargo>();

        var item = await repo.GetByIdAsync(request.Id);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
