using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Vehiculos.Queries;

public record GetVehiculoByIdQuery(int Id) : IRequest<Domain.Entities.Vehiculo>;

internal sealed class GetVehiculoByIdQueryHandler : IRequestHandler<GetVehiculoByIdQuery, Domain.Entities.Vehiculo>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetVehiculoByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.Vehiculo> Handle(GetVehiculoByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.Vehiculo>().GetByIdAsync(request.Id))!;
    }
}
