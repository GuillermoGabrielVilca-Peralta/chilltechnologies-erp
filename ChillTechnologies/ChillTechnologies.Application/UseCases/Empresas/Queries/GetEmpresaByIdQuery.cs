using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Empresas.Queries;

public record GetEmpresaByIdQuery(int Id) : IRequest<Domain.Entities.Empresa>;

internal sealed class GetEmpresaByIdQueryHandler : IRequestHandler<GetEmpresaByIdQuery, Domain.Entities.Empresa>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetEmpresaByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.Empresa> Handle(GetEmpresaByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.Empresa>().GetByIdAsync(request.Id))!;
    }
}
