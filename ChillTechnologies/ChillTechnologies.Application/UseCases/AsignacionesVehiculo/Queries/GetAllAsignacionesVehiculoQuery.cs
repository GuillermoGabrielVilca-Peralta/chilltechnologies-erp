using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.AsignacionesVehiculo.Queries;

public record GetAllAsignacionesVehiculoQuery : IRequest<IEnumerable<Domain.Entities.AsignacionesVehiculo>>;

internal sealed class GetAllAsignacionesVehiculoQueryHandler : IRequestHandler<GetAllAsignacionesVehiculoQuery, IEnumerable<Domain.Entities.AsignacionesVehiculo>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllAsignacionesVehiculoQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.AsignacionesVehiculo>> Handle(GetAllAsignacionesVehiculoQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.AsignacionesVehiculo>().GetAllAsync();
    }
}
