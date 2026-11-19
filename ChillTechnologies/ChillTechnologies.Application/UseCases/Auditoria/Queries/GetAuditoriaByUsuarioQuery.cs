using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Auditoria.Queries;

public record GetAuditoriaByUsuarioQuery(int UsuarioSistemaId) : IRequest<IEnumerable<Domain.Entities.Auditorium>>;

internal sealed class GetAuditoriaByUsuarioQueryHandler : IRequestHandler<GetAuditoriaByUsuarioQuery, IEnumerable<Domain.Entities.Auditorium>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAuditoriaByUsuarioQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.Auditorium>> Handle(GetAuditoriaByUsuarioQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.Auditorium>()
            .FindAsync(a => a.UsuarioSistemaId == request.UsuarioSistemaId);
    }
}
