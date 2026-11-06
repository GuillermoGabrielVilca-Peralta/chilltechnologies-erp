using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Areas.Queries;

public record GetAreaByIdQuery(int Id) : IRequest<Domain.Entities.Area>;

internal sealed class GetAreaByIdQueryHandler : IRequestHandler<GetAreaByIdQuery, Domain.Entities.Area>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAreaByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.Area> Handle(GetAreaByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.Area>().GetByIdAsync(request.Id))!;
    }
}
