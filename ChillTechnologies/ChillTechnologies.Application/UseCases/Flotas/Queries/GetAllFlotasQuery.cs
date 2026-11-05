using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Flotas.Queries;

public record GetAllFlotasQuery : IRequest<IEnumerable<Domain.Entities.Flota>>;

internal sealed class GetAllFlotasQueryHandler : IRequestHandler<GetAllFlotasQuery, IEnumerable<Domain.Entities.Flota>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllFlotasQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.Flota>> Handle(GetAllFlotasQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.Flota>().GetAllAsync();
    }
}
