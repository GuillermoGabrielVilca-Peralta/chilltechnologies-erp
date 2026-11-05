using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.AsignacionesVehiculo.Commands;

public record CreateAsignacionVehiculoCommand : IRequest<int>
{
    public int VehiculoId { get; set; }
    public int UsuarioId { get; set; }
}

internal sealed class CreateAsignacionVehiculoCommandHandler : IRequestHandler<CreateAsignacionVehiculoCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateAsignacionVehiculoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateAsignacionVehiculoCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.AsignacionesVehiculo
        {
            VehiculoId = request.VehiculoId,
            UsuarioId = request.UsuarioId,
            FechaInicio = DateTime.Now,
            Estado = "Activa"
        };

        await _unitOfWork.Repository<Domain.Entities.AsignacionesVehiculo>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}
