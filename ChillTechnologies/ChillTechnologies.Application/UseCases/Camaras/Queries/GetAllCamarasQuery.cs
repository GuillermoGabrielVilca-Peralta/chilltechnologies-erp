using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Camaras.Queries;

public record GetAllCamarasQuery : IRequest<IEnumerable<Domain.Entities.Camara>>;

internal sealed class GetAllCamarasQueryHandler : IRequestHandler<GetAllCamarasQuery, IEnumerable<Domain.Entities.Camara>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllCamarasQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.Camara>> Handle(GetAllCamarasQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.Camara>().GetAllAsync();
    }
}
