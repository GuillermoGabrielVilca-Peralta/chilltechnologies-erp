using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.DocumentosVehiculo.Queries;

public record GetAllDocumentosVehiculoQuery : IRequest<IEnumerable<Domain.Entities.DocumentosVehiculo>>;

internal sealed class GetAllDocumentosVehiculoQueryHandler : IRequestHandler<GetAllDocumentosVehiculoQuery, IEnumerable<Domain.Entities.DocumentosVehiculo>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllDocumentosVehiculoQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.DocumentosVehiculo>> Handle(GetAllDocumentosVehiculoQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.DocumentosVehiculo>().GetAllAsync();
    }
}
