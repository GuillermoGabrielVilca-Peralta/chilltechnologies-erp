using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.HistoriasUsuario.Queries;

public record GetHistoriaUsuarioByIdQuery(int Id) : IRequest<Domain.Entities.HistoriasUsuario>;

internal sealed class GetHistoriaUsuarioByIdQueryHandler : IRequestHandler<GetHistoriaUsuarioByIdQuery, Domain.Entities.HistoriasUsuario>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetHistoriaUsuarioByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.HistoriasUsuario> Handle(GetHistoriaUsuarioByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.HistoriasUsuario>().GetByIdAsync(request.Id))!;
    }
}
