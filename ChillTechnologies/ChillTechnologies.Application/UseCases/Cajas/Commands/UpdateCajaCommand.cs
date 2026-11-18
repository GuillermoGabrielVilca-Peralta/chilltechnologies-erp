using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Cajas.Commands;

public record UpdateCajaCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public int? ResponsableEmpleadoId { get; set; }
    public string Estado { get; set; } = null!;
}

internal sealed class UpdateCajaCommandHandler : IRequestHandler<UpdateCajaCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCajaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateCajaCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Caja>();

        var item = await repo.GetByIdAsync(request.Id);

        item!.Nombre = request.Nombre;
        item.ResponsableEmpleadoId = request.ResponsableEmpleadoId;
        item.Estado = request.Estado;

        repo.Update(item);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
