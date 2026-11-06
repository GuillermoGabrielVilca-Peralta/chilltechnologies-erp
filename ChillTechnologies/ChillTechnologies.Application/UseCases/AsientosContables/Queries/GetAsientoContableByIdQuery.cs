using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.AsientosContables.Queries;

public record GetAsientoContableByIdQuery(int Id) : IRequest<Domain.Entities.AsientosContable>;

internal sealed class GetAsientoContableByIdQueryHandler : IRequestHandler<GetAsientoContableByIdQuery, Domain.Entities.AsientosContable>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAsientoContableByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.AsientosContable> Handle(GetAsientoContableByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.AsientosContable>().GetByIdAsync(request.Id))!;
    }
}
