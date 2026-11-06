using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Recepciones.Queries;

public record GetAllRecepcionesQuery : IRequest<IEnumerable<Domain.Entities.Recepcione>>;

internal sealed class GetAllRecepcionesQueryHandler : IRequestHandler<GetAllRecepcionesQuery, IEnumerable<Domain.Entities.Recepcione>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllRecepcionesQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.Recepcione>> Handle(GetAllRecepcionesQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.Recepcione>().GetAllAsync();
    }
}
