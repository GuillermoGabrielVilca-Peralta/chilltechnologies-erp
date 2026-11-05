using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.ReglasScoring.Queries;

public record GetReglaScoringByIdQuery(int Id) : IRequest<Domain.Entities.ReglasScoring>;

internal sealed class GetReglaScoringByIdQueryHandler : IRequestHandler<GetReglaScoringByIdQuery, Domain.Entities.ReglasScoring>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetReglaScoringByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.ReglasScoring> Handle(GetReglaScoringByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.ReglasScoring>().GetByIdAsync(request.Id))!;
    }
}
