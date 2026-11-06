using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Almacenes.Commands;

public record CreateAlmacenCommand : IRequest<int>
{
    public string Nombre { get; set; } = null!;
    public string? Direccion { get; set; }
    public int? ResponsableEmpleadoId { get; set; }
}

internal sealed class CreateAlmacenCommandHandler : IRequestHandler<CreateAlmacenCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateAlmacenCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateAlmacenCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.Almacene
        {
            Nombre = request.Nombre,
            Direccion = request.Direccion,
            ResponsableEmpleadoId = request.ResponsableEmpleadoId,
            Estado = "Activo",
            FechaRegistro = DateTime.Now
        };

        await _unitOfWork.Repository<Domain.Entities.Almacene>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}
