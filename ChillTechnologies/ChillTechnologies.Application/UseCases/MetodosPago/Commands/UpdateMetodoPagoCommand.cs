using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.MetodosPago.Commands;

public record UpdateMetodoPagoCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
}

internal sealed class UpdateMetodoPagoCommandHandler : IRequestHandler<UpdateMetodoPagoCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateMetodoPagoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateMetodoPagoCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.MetodosPago>();

        var item = await repo.GetByIdAsync(request.Id);

        item!.Nombre = request.Nombre;

        repo.Update(item);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
