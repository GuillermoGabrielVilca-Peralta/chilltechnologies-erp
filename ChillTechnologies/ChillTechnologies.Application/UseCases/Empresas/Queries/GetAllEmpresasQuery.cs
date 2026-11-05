using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Empresas.Queries;

public record GetAllEmpresasQuery : IRequest<IEnumerable<Domain.Entities.Empresa>>;

internal sealed class GetAllEmpresasQueryHandler : IRequestHandler<GetAllEmpresasQuery, IEnumerable<Domain.Entities.Empresa>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllEmpresasQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.Empresa>> Handle(GetAllEmpresasQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.Empresa>().GetAllAsync();
    }
}
