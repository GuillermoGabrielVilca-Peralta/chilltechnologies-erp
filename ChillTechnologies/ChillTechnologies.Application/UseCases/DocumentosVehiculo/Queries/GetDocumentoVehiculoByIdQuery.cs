using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.DocumentosVehiculo.Queries;

public record GetDocumentoVehiculoByIdQuery(int Id) : IRequest<Domain.Entities.DocumentosVehiculo>;

internal sealed class GetDocumentoVehiculoByIdQueryHandler : IRequestHandler<GetDocumentoVehiculoByIdQuery, Domain.Entities.DocumentosVehiculo>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetDocumentoVehiculoByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.DocumentosVehiculo> Handle(GetDocumentoVehiculoByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.DocumentosVehiculo>().GetByIdAsync(request.Id))!;
    }
}
