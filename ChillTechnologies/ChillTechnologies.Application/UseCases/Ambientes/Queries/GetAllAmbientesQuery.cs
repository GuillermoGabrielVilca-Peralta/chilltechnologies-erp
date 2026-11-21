using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Ambientes.Queries;

public record GetAllAmbientesQuery : IRequest<IEnumerable<Domain.Entities.Ambiente>>;

internal sealed class GetAllAmbientesQueryHandler : IRequestHandler<GetAllAmbientesQuery, IEnumerable<Domain.Entities.Ambiente>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllAmbientesQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.Ambiente>> Handle(GetAllAmbientesQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.Ambiente>().GetAllAsync();
    }
}
