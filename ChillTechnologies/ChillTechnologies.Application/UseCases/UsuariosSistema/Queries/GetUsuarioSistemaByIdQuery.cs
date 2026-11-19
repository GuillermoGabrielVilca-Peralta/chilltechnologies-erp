using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.UsuariosSistema.Queries;

public record GetUsuarioSistemaByIdQuery(int Id) : IRequest<Domain.Entities.UsuariosSistema>;

internal sealed class GetUsuarioSistemaByIdQueryHandler : IRequestHandler<GetUsuarioSistemaByIdQuery, Domain.Entities.UsuariosSistema>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetUsuarioSistemaByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.UsuariosSistema> Handle(GetUsuarioSistemaByIdQuery request, CancellationToken cancellationToken)
    {
        return (await _unitOfWork.Repository<Domain.Entities.UsuariosSistema>().GetByIdAsync(request.Id))!;
    }
}
