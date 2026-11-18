using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Cajas.Queries;

public record GetAllCajasQuery : IRequest<IEnumerable<Domain.Entities.Caja>>;

internal sealed class GetAllCajasQueryHandler : IRequestHandler<GetAllCajasQuery, IEnumerable<Domain.Entities.Caja>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllCajasQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.Caja>> Handle(GetAllCajasQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.Caja>().GetAllAsync();
    }
}
