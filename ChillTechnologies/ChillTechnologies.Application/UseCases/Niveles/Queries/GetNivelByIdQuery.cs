using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Niveles.Queries;

public record GetNivelByIdQuery(int Id) : IRequest<Domain.Entities.Nivele>;

internal sealed class GetNivelByIdQueryHandler : IRequestHandler<GetNivelByIdQuery, Domain.Entities.Nivele>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetNivelByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.Nivele> Handle(GetNivelByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.Nivele>().GetByIdAsync(request.Id))!;
    }
}
