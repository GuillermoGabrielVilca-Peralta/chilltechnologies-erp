using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.MovimientosBancarios.Queries;

public record GetMovimientoBancarioByIdQuery(int Id) : IRequest<Domain.Entities.MovimientosBancario>;

internal sealed class GetMovimientoBancarioByIdQueryHandler : IRequestHandler<GetMovimientoBancarioByIdQuery, Domain.Entities.MovimientosBancario>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetMovimientoBancarioByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.MovimientosBancario> Handle(GetMovimientoBancarioByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.MovimientosBancario>().GetByIdAsync(request.Id))!;
    }
}
