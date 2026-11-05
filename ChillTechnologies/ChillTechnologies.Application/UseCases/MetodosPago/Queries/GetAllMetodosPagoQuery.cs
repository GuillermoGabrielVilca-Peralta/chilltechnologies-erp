using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.MetodosPago.Queries;

public record GetAllMetodosPagoQuery : IRequest<IEnumerable<Domain.Entities.MetodosPago>>;

internal sealed class GetAllMetodosPagoQueryHandler : IRequestHandler<GetAllMetodosPagoQuery, IEnumerable<Domain.Entities.MetodosPago>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllMetodosPagoQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.MetodosPago>> Handle(GetAllMetodosPagoQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.MetodosPago>().GetAllAsync();
    }
}
