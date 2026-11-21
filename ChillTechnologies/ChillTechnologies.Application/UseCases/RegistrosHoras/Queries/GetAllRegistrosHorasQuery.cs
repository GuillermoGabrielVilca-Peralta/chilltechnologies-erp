using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.RegistrosHoras.Queries;

public record GetAllRegistrosHorasQuery : IRequest<IEnumerable<Domain.Entities.RegistrosHora>>;

internal sealed class GetAllRegistrosHorasQueryHandler : IRequestHandler<GetAllRegistrosHorasQuery, IEnumerable<Domain.Entities.RegistrosHora>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllRegistrosHorasQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.RegistrosHora>> Handle(GetAllRegistrosHorasQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.RegistrosHora>().GetAllAsync();
    }
}
