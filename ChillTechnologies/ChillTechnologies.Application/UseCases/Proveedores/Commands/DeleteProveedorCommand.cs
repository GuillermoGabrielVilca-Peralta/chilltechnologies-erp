using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Proveedores.Commands;

public record DeleteProveedorCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteProveedorCommandHandler : IRequestHandler<DeleteProveedorCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProveedorCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteProveedorCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Proveedore>();

        var item = await repo.GetByIdAsync(request.Id);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
