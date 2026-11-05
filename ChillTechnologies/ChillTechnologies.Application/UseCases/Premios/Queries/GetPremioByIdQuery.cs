using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Premios.Queries;

public record GetPremioByIdQuery(int Id) : IRequest<Domain.Entities.Premio>;

internal sealed class GetPremioByIdQueryHandler : IRequestHandler<GetPremioByIdQuery, Domain.Entities.Premio>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetPremioByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.Premio> Handle(GetPremioByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.Premio>().GetByIdAsync(request.Id))!;
    }
}
