using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.CuentasBancarias.Queries;

public record GetAllCuentasBancariasQuery : IRequest<IEnumerable<Domain.Entities.CuentasBancaria>>;

internal sealed class GetAllCuentasBancariasQueryHandler : IRequestHandler<GetAllCuentasBancariasQuery, IEnumerable<Domain.Entities.CuentasBancaria>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllCuentasBancariasQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.CuentasBancaria>> Handle(GetAllCuentasBancariasQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.CuentasBancaria>().GetAllAsync();
    }
}
