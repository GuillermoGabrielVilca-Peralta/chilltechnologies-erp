using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.CuentasBancarias.Commands;

public record DeleteCuentaBancariaCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteCuentaBancariaCommandHandler : IRequestHandler<DeleteCuentaBancariaCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCuentaBancariaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteCuentaBancariaCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.CuentasBancaria>();

        var item = await repo.GetByIdAsync(request.Id);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
