using MediatR;
using ChillTechnologies.Application.DTOsRespuesta;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Usuarios.Queries;

public record GetAllUsuariosQuery : IRequest<IEnumerable<UsuarioResponse>>;

internal sealed class GetAllUsuariosQueryHandler : IRequestHandler<GetAllUsuariosQuery, IEnumerable<UsuarioResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllUsuariosQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<UsuarioResponse>> Handle(GetAllUsuariosQuery request, CancellationToken cancellationToken)
    {
        var usuarios = await _unitOfWork.Repository<Domain.Entities.Usuario>().GetAllAsync();
        
        var planes = (await _unitOfWork.Repository<Domain.Entities.Plane>().GetAllAsync())
            .ToDictionary(p => p.Id, p => p.Nombre);
        var tipos = (await _unitOfWork.Repository<Domain.Entities.TiposConductor>().GetAllAsync())
            .ToDictionary(t => t.Id, t => t.Nombre);
        var empresas = (await _unitOfWork.Repository<Domain.Entities.Empresa>().GetAllAsync())
            .ToDictionary(e => e.Id, e => e.RazonSocial);

        return usuarios.Select(u => new UsuarioResponse
        {
            Id = u.Id,
            Nombres = u.Nombres,
            Apellidos = u.Apellidos,
            NombreCompleto = $"{u.Nombres} {u.Apellidos}",
            Correo = u.Correo,
            Telefono = u.Telefono,
            FotoPerfil = u.FotoPerfil,
            PlanId = u.PlanId,
            PlanNombre = planes.GetValueOrDefault(u.PlanId, ""),
            TipoConductorId = u.TipoConductorId,
            TipoConductorNombre = tipos.GetValueOrDefault(u.TipoConductorId, ""),
            EmpresaId = u.EmpresaId,
            EmpresaRazonSocial = u.EmpresaId == null ? null : empresas.GetValueOrDefault(u.EmpresaId.Value),
            Estado = u.Estado,
            UltimoAcceso = u.UltimoAcceso,
            FechaRegistro = u.FechaRegistro
        });
    }
}
