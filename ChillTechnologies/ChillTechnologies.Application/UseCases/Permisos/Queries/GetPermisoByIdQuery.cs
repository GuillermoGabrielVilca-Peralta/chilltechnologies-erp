using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Permisos.Queries;

public record GetPermisoByIdQuery(int Id) : IRequest<Domain.Entities.Permiso>;

internal sealed class GetPermisoByIdQueryHandler : IRequestHandler<GetPermisoByIdQuery, Domain.Entities.Permiso>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetPermisoByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.Permiso> Handle(GetPermisoByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.Permiso>().GetByIdAsync(request.Id))!;
    }
}
