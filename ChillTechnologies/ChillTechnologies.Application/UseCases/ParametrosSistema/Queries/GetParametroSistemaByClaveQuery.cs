using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.ParametrosSistema.Queries;

public record GetParametroSistemaByClaveQuery(string Clave) : IRequest<Domain.Entities.ParametrosSistema>;

internal sealed class GetParametroSistemaByClaveQueryHandler : IRequestHandler<GetParametroSistemaByClaveQuery, Domain.Entities.ParametrosSistema>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetParametroSistemaByClaveQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.ParametrosSistema> Handle(GetParametroSistemaByClaveQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.ParametrosSistema>()
            .FirstOrDefaultAsync(p => p.Clave == request.Clave))!;
    }
}
