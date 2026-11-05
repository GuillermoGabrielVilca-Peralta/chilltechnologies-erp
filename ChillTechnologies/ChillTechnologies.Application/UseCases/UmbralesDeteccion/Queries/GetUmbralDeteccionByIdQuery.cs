using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.UmbralesDeteccion.Queries;

public record GetUmbralDeteccionByIdQuery(int Id) : IRequest<Domain.Entities.UmbralesDeteccion>;

internal sealed class GetUmbralDeteccionByIdQueryHandler : IRequestHandler<GetUmbralDeteccionByIdQuery, Domain.Entities.UmbralesDeteccion>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetUmbralDeteccionByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.UmbralesDeteccion> Handle(GetUmbralDeteccionByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.UmbralesDeteccion>().GetByIdAsync(request.Id))!;
    }
}
