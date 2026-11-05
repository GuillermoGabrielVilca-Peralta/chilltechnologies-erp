using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.AsignacionesVehiculo.Queries;

public record GetAsignacionVehiculoByIdQuery(int Id) : IRequest<Domain.Entities.AsignacionesVehiculo>;

internal sealed class GetAsignacionVehiculoByIdQueryHandler : IRequestHandler<GetAsignacionVehiculoByIdQuery, Domain.Entities.AsignacionesVehiculo>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAsignacionVehiculoByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.AsignacionesVehiculo> Handle(GetAsignacionVehiculoByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.AsignacionesVehiculo>().GetByIdAsync(request.Id))!;
    }
}
