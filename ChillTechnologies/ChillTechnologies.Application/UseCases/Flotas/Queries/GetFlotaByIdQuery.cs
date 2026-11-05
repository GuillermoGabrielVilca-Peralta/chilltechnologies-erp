using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Flotas.Queries;

public record GetFlotaByIdQuery(int Id) : IRequest<Domain.Entities.Flota>;

internal sealed class GetFlotaByIdQueryHandler : IRequestHandler<GetFlotaByIdQuery, Domain.Entities.Flota>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetFlotaByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.Flota> Handle(GetFlotaByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.Flota>().GetByIdAsync(request.Id))!;
    }
}
