using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Polizas.Queries;

public record GetPolizaByIdQuery(int Id) : IRequest<Domain.Entities.Poliza>;

internal sealed class GetPolizaByIdQueryHandler : IRequestHandler<GetPolizaByIdQuery, Domain.Entities.Poliza>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetPolizaByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.Poliza> Handle(GetPolizaByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.Poliza>().GetByIdAsync(request.Id))!;
    }
}
