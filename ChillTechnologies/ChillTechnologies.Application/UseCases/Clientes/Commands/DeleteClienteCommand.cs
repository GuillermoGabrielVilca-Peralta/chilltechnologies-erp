using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Clientes.Commands;

public record DeleteClienteCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteClienteCommandHandler : IRequestHandler<DeleteClienteCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteClienteCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteClienteCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Cliente>();

        var item = await repo.GetByIdAsync(request.Id);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
