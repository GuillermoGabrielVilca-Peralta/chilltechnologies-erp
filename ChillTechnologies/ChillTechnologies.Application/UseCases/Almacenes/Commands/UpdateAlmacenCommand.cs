using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Almacenes.Commands;

public record UpdateAlmacenCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Direccion { get; set; }
    public int? ResponsableEmpleadoId { get; set; }
    //activo,inactivo
    public string Estado { get; set; } = null!;
}

internal sealed class UpdateAlmacenCommandHandler : IRequestHandler<UpdateAlmacenCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAlmacenCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateAlmacenCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Almacene>();

        var item = await repo.GetByIdAsync(request.Id);

        item!.Nombre = request.Nombre;
        item.Direccion = request.Direccion;
        item.ResponsableEmpleadoId = request.ResponsableEmpleadoId;
        item.Estado = request.Estado;

        repo.Update(item);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
