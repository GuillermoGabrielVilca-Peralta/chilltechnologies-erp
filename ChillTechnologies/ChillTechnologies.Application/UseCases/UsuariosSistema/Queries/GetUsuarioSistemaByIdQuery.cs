using MediatR;
using ChillTechnologies.Application.DTOsRespuesta;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.UsuariosSistema.Queries;

public record GetUsuarioSistemaByIdQuery(int Id) : IRequest<UsuarioSistemaResponse>;

internal sealed class GetUsuarioSistemaByIdQueryHandler : IRequestHandler<GetUsuarioSistemaByIdQuery, UsuarioSistemaResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetUsuarioSistemaByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<UsuarioSistemaResponse> Handle(GetUsuarioSistemaByIdQuery request, CancellationToken cancellationToken)
    {
        var u = (await _unitOfWork.Repository<Domain.Entities.UsuariosSistema>().GetByIdAsync(request.Id))!;

        var empleado = await _unitOfWork.Repository<Domain.Entities.Empleado>().GetByIdAsync(u.EmpleadoId);

        var rolIds = (await _unitOfWork.Repository<Domain.Entities.UsuarioRol>()
                .FindAsync(ur => ur.UsuarioSistemaId == u.Id))
            .Select(ur => ur.RolId)
            .ToList();

        var roles = (await _unitOfWork.Repository<Domain.Entities.RolesSistema>()
                .FindAsync(r => rolIds.Contains(r.Id)))
            .Select(r => r.Nombre)
            .ToList();

        return new UsuarioSistemaResponse
        {
            Id = u.Id,
            EmpleadoId = u.EmpleadoId,
            EmpleadoNombre = empleado == null ? "" : $"{empleado.Nombres} {empleado.Apellidos}",
            Username = u.Username,
            Estado = u.Estado,
            UltimoAcceso = u.UltimoAcceso,
            FechaRegistro = u.FechaRegistro,
            Roles = roles
        };
    }
}
