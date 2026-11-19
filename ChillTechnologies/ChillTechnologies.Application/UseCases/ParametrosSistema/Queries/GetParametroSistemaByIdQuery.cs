using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.ParametrosSistema.Queries;

public record GetParametroSistemaByIdQuery(int Id) : IRequest<Domain.Entities.ParametrosSistema>;

internal sealed class GetParametroSistemaByIdQueryHandler : IRequestHandler<GetParametroSistemaByIdQuery, Domain.Entities.ParametrosSistema>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetParametroSistemaByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.ParametrosSistema> Handle(GetParametroSistemaByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.ParametrosSistema>().GetByIdAsync(request.Id))!;
    }
}
