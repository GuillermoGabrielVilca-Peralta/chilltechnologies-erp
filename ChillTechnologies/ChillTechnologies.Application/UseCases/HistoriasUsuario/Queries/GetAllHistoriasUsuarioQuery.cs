using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.HistoriasUsuario.Queries;

public record GetAllHistoriasUsuarioQuery : IRequest<IEnumerable<Domain.Entities.HistoriasUsuario>>;

internal sealed class GetAllHistoriasUsuarioQueryHandler : IRequestHandler<GetAllHistoriasUsuarioQuery, IEnumerable<Domain.Entities.HistoriasUsuario>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllHistoriasUsuarioQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.HistoriasUsuario>> Handle(GetAllHistoriasUsuarioQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.HistoriasUsuario>().GetAllAsync();
    }
}
