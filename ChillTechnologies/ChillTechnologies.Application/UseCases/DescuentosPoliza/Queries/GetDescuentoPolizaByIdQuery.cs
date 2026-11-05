using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.DescuentosPoliza.Queries;

public record GetDescuentoPolizaByIdQuery(int Id) : IRequest<Domain.Entities.DescuentosPoliza>;

internal sealed class GetDescuentoPolizaByIdQueryHandler : IRequestHandler<GetDescuentoPolizaByIdQuery, Domain.Entities.DescuentosPoliza>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetDescuentoPolizaByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.DescuentosPoliza> Handle(GetDescuentoPolizaByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.DescuentosPoliza>().GetByIdAsync(request.Id))!;
    }
}
