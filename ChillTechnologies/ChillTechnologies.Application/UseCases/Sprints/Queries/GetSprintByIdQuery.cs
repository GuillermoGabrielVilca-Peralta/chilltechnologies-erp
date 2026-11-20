using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Sprints.Queries;

public record GetSprintByIdQuery(int Id) : IRequest<Domain.Entities.Sprint>;

internal sealed class GetSprintByIdQueryHandler : IRequestHandler<GetSprintByIdQuery, Domain.Entities.Sprint>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetSprintByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.Sprint> Handle(GetSprintByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.Sprint>().GetByIdAsync(request.Id))!;
    }
}
