using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Pagos.Queries;

public record GetAllPagosQuery : IRequest<IEnumerable<Domain.Entities.Pago>>;

internal sealed class GetAllPagosQueryHandler : IRequestHandler<GetAllPagosQuery, IEnumerable<Domain.Entities.Pago>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllPagosQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.Pago>> Handle(GetAllPagosQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.Pago>().GetAllAsync();
    }
}
