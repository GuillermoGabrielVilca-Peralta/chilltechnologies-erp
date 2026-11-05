using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Paradas.Queries;

public record GetParadaByIdQuery(int Id) : IRequest<Domain.Entities.Parada>;

internal sealed class GetParadaByIdQueryHandler : IRequestHandler<GetParadaByIdQuery, Domain.Entities.Parada>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetParadaByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.Parada> Handle(GetParadaByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.Parada>().GetByIdAsync(request.Id))!;
    }
}
