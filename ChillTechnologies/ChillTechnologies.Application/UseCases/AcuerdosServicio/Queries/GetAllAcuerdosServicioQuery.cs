using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.AcuerdosServicio.Queries;

public record GetAllAcuerdosServicioQuery : IRequest<IEnumerable<Domain.Entities.AcuerdosServicio>>;

internal sealed class GetAllAcuerdosServicioQueryHandler : IRequestHandler<GetAllAcuerdosServicioQuery, IEnumerable<Domain.Entities.AcuerdosServicio>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllAcuerdosServicioQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.AcuerdosServicio>> Handle(GetAllAcuerdosServicioQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.AcuerdosServicio>().GetAllAsync();
    }
}
