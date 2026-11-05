using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.TiposVehiculo.Queries;

public record GetAllTiposVehiculoQuery : IRequest<IEnumerable<Domain.Entities.TiposVehiculo>>;

internal sealed class GetAllTiposVehiculoQueryHandler : IRequestHandler<GetAllTiposVehiculoQuery, IEnumerable<Domain.Entities.TiposVehiculo>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllTiposVehiculoQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.TiposVehiculo>> Handle(GetAllTiposVehiculoQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.TiposVehiculo>().GetAllAsync();
    }
}
