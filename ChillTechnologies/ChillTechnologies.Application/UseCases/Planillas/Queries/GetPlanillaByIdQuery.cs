using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Planillas.Queries;

public record GetPlanillaByIdQuery(int Id) : IRequest<Domain.Entities.Planilla>;

internal sealed class GetPlanillaByIdQueryHandler : IRequestHandler<GetPlanillaByIdQuery, Domain.Entities.Planilla>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetPlanillaByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.Planilla> Handle(GetPlanillaByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.Planilla>().GetByIdAsync(request.Id))!;
    }
}
