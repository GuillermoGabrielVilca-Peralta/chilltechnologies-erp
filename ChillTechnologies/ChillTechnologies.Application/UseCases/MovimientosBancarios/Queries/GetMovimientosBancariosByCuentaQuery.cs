using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.MovimientosBancarios.Queries;

public record GetMovimientosBancariosByCuentaQuery(int CuentaBancariaId) : IRequest<IEnumerable<Domain.Entities.MovimientosBancario>>;

internal sealed class GetMovimientosBancariosByCuentaQueryHandler : IRequestHandler<GetMovimientosBancariosByCuentaQuery, IEnumerable<Domain.Entities.MovimientosBancario>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetMovimientosBancariosByCuentaQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.MovimientosBancario>> Handle(GetMovimientosBancariosByCuentaQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.MovimientosBancario>()
            .FindAsync(m => m.CuentaBancariaId == request.CuentaBancariaId);
    }
}
