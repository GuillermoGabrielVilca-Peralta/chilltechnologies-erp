using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.TiposVehiculo.Queries;

public record GetTipoVehiculoByIdQuery(int Id) : IRequest<Domain.Entities.TiposVehiculo>;

internal sealed class GetTipoVehiculoByIdQueryHandler : IRequestHandler<GetTipoVehiculoByIdQuery, Domain.Entities.TiposVehiculo>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetTipoVehiculoByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.TiposVehiculo> Handle(GetTipoVehiculoByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.TiposVehiculo>().GetByIdAsync(request.Id))!;
    }
}
