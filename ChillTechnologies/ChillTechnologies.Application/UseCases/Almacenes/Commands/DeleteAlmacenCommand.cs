using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Almacenes.Commands;

public record DeleteAlmacenCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteAlmacenCommandHandler : IRequestHandler<DeleteAlmacenCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAlmacenCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteAlmacenCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Almacene>();

        var item = await repo.GetByIdAsync(request.Id);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
