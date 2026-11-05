using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Planes.Commands;

public record UpdatePlanCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public decimal PrecioSoles { get; set; }
    public string? Descripcion { get; set; }
}

internal sealed class UpdatePlanCommandHandler : IRequestHandler<UpdatePlanCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePlanCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdatePlanCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Plane>();

        var item = await repo.GetByIdAsync(request.Id);

        item!.Nombre = request.Nombre;
        item.PrecioSoles = request.PrecioSoles;
        item.Descripcion = request.Descripcion;

        repo.Update(item);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
