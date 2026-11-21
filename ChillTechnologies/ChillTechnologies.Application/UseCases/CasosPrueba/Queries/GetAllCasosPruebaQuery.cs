using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.CasosPrueba.Queries;

public record GetAllCasosPruebaQuery : IRequest<IEnumerable<Domain.Entities.CasosPrueba>>;

internal sealed class GetAllCasosPruebaQueryHandler : IRequestHandler<GetAllCasosPruebaQuery, IEnumerable<Domain.Entities.CasosPrueba>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllCasosPruebaQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.CasosPrueba>> Handle(GetAllCasosPruebaQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.CasosPrueba>().GetAllAsync();
    }
}
