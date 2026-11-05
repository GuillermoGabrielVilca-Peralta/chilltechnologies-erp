using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Vehiculos.Queries;

public record GetAllVehiculosQuery : IRequest<IEnumerable<Domain.Entities.Vehiculo>>;

internal sealed class GetAllVehiculosQueryHandler : IRequestHandler<GetAllVehiculosQuery, IEnumerable<Domain.Entities.Vehiculo>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllVehiculosQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.Vehiculo>> Handle(GetAllVehiculosQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.Vehiculo>().GetAllAsync();
    }
}
