using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.UmbralesDeteccion.Queries;

public record GetAllUmbralesDeteccionQuery : IRequest<IEnumerable<Domain.Entities.UmbralesDeteccion>>;

internal sealed class GetAllUmbralesDeteccionQueryHandler : IRequestHandler<GetAllUmbralesDeteccionQuery, IEnumerable<Domain.Entities.UmbralesDeteccion>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllUmbralesDeteccionQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.UmbralesDeteccion>> Handle(GetAllUmbralesDeteccionQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.UmbralesDeteccion>().GetAllAsync();
    }
}
