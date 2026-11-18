using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.MovimientosBancarios.Commands;

public record ConciliarMovimientoBancarioCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public bool Conciliado { get; set; }
}

internal sealed class ConciliarMovimientoBancarioCommandHandler : IRequestHandler<ConciliarMovimientoBancarioCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public ConciliarMovimientoBancarioCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(ConciliarMovimientoBancarioCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.MovimientosBancario>();

        var item = await repo.GetByIdAsync(request.Id);

        item!.Conciliado = request.Conciliado;

        repo.Update(item);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
