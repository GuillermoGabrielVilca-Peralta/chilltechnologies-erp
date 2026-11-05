using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.ReglasScoring.Queries;

public record GetAllReglasScoringQuery : IRequest<IEnumerable<Domain.Entities.ReglasScoring>>;

internal sealed class GetAllReglasScoringQueryHandler : IRequestHandler<GetAllReglasScoringQuery, IEnumerable<Domain.Entities.ReglasScoring>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllReglasScoringQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.ReglasScoring>> Handle(GetAllReglasScoringQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.ReglasScoring>().GetAllAsync();
    }
}
