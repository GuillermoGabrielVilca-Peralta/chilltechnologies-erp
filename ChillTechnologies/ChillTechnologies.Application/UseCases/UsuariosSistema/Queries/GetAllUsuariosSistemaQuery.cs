using MediatR;
using ChillTechnologies.Application.DTOsRespuesta;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.UsuariosSistema.Queries;

public record GetAllUsuariosSistemaQuery : IRequest<IEnumerable<UsuarioSistemaResponse>>;

internal sealed class GetAllUsuariosSistemaQueryHandler : IRequestHandler<GetAllUsuariosSistemaQuery, IEnumerable<UsuarioSistemaResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllUsuariosSistemaQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<UsuarioSistemaResponse>> Handle(GetAllUsuariosSistemaQuery request, CancellationToken cancellationToken)
    {
        var usuarios = await _unitOfWork.Repository<Domain.Entities.UsuariosSistema>().GetAllAsync();

        var empleados = (await _unitOfWork.Repository<Domain.Entities.Empleado>().GetAllAsync())
            .ToDictionary(e => e.Id, e => $"{e.Nombres} {e.Apellidos}");

        var asignaciones = await _unitOfWork.Repository<Domain.Entities.UsuarioRol>().GetAllAsync();
        var nombresRol = (await _unitOfWork.Repository<Domain.Entities.RolesSistema>().GetAllAsync())
            .ToDictionary(r => r.Id, r => r.Nombre);

        var rolesPorUsuario = asignaciones
            .GroupBy(ur => ur.UsuarioSistemaId)
            .ToDictionary(
                g => g.Key,
                g => g.Select(ur => nombresRol.GetValueOrDefault(ur.RolId, "")).Where(n => n != "").ToList());

        return usuarios.Select(u => new UsuarioSistemaResponse
        {
            Id = u.Id,
            EmpleadoId = u.EmpleadoId,
            EmpleadoNombre = empleados.GetValueOrDefault(u.EmpleadoId, ""),
            Username = u.Username,
            Estado = u.Estado,
            UltimoAcceso = u.UltimoAcceso,
            FechaRegistro = u.FechaRegistro,
            Roles = rolesPorUsuario.GetValueOrDefault(u.Id, [])
        });
    }
}
