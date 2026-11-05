using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Paradas.Queries;

public record GetAllParadasQuery : IRequest<IEnumerable<Domain.Entities.Parada>>;

internal sealed class GetAllParadasQueryHandler : IRequestHandler<GetAllParadasQuery, IEnumerable<Domain.Entities.Parada>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllParadasQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.Parada>> Handle(GetAllParadasQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.Parada>().GetAllAsync();
    }
}
