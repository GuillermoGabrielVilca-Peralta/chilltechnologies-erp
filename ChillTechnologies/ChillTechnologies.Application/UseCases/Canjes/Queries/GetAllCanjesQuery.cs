using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Canjes.Queries;

public record GetAllCanjesQuery : IRequest<IEnumerable<Domain.Entities.Canje>>;

internal sealed class GetAllCanjesQueryHandler : IRequestHandler<GetAllCanjesQuery, IEnumerable<Domain.Entities.Canje>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllCanjesQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.Canje>> Handle(GetAllCanjesQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.Canje>().GetAllAsync();
    }
}
