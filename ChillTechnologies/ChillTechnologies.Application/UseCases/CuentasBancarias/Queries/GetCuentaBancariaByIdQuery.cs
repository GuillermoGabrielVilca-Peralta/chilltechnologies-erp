using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.CuentasBancarias.Queries;

public record GetCuentaBancariaByIdQuery(int Id) : IRequest<Domain.Entities.CuentasBancaria>;

internal sealed class GetCuentaBancariaByIdQueryHandler : IRequestHandler<GetCuentaBancariaByIdQuery, Domain.Entities.CuentasBancaria>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCuentaBancariaByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.CuentasBancaria> Handle(GetCuentaBancariaByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.CuentasBancaria>().GetByIdAsync(request.Id))!;
    }
}
