using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.DescuentosPoliza.Queries;

public record GetAllDescuentosPolizaQuery : IRequest<IEnumerable<Domain.Entities.DescuentosPoliza>>;

internal sealed class GetAllDescuentosPolizaQueryHandler : IRequestHandler<GetAllDescuentosPolizaQuery, IEnumerable<Domain.Entities.DescuentosPoliza>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllDescuentosPolizaQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.DescuentosPoliza>> Handle(GetAllDescuentosPolizaQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.DescuentosPoliza>().GetAllAsync();
    }
}
