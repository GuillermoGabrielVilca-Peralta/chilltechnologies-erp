using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.ParametrosSistema.Queries;

public record GetAllParametrosSistemaQuery : IRequest<IEnumerable<Domain.Entities.ParametrosSistema>>;

internal sealed class GetAllParametrosSistemaQueryHandler : IRequestHandler<GetAllParametrosSistemaQuery, IEnumerable<Domain.Entities.ParametrosSistema>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllParametrosSistemaQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.ParametrosSistema>> Handle(GetAllParametrosSistemaQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.ParametrosSistema>().GetAllAsync();
    }
}
