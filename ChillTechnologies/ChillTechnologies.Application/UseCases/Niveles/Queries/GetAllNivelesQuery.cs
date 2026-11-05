using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Niveles.Queries;

public record GetAllNivelesQuery : IRequest<IEnumerable<Domain.Entities.Nivele>>;

internal sealed class GetAllNivelesQueryHandler : IRequestHandler<GetAllNivelesQuery, IEnumerable<Domain.Entities.Nivele>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllNivelesQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.Nivele>> Handle(GetAllNivelesQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.Nivele>().GetAllAsync();
    }
}
