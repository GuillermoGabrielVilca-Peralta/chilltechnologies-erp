using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Premios.Queries;

public record GetAllPremiosQuery : IRequest<IEnumerable<Domain.Entities.Premio>>;

internal sealed class GetAllPremiosQueryHandler : IRequestHandler<GetAllPremiosQuery, IEnumerable<Domain.Entities.Premio>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllPremiosQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.Premio>> Handle(GetAllPremiosQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.Premio>().GetAllAsync();
    }
}
