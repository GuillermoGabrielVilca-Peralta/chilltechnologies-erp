using MediatR;
using ChillTechnologies.Application.DTOsRespuesta;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Usuarios.Queries;

public record GetUsuarioByIdQuery(int Id) : IRequest<UsuarioResponse>;

internal sealed class GetUsuarioByIdQueryHandler : IRequestHandler<GetUsuarioByIdQuery, UsuarioResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetUsuarioByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<UsuarioResponse> Handle(GetUsuarioByIdQuery request, CancellationToken cancellationToken)
    {
        var u = (await _unitOfWork.Repository<Domain.Entities.Usuario>().GetByIdAsync(request.Id))!;

        var plan = await _unitOfWork.Repository<Domain.Entities.Plane>().GetByIdAsync(u.PlanId);
        var tipo = await _unitOfWork.Repository<Domain.Entities.TiposConductor>().GetByIdAsync(u.TipoConductorId);
        var empresa = u.EmpresaId == null
            ? null
            : await _unitOfWork.Repository<Domain.Entities.Empresa>().GetByIdAsync(u.EmpresaId);

        return new UsuarioResponse
        {
            Id = u.Id,
            Nombres = u.Nombres,
            Apellidos = u.Apellidos,
            NombreCompleto = $"{u.Nombres} {u.Apellidos}",
            Correo = u.Correo,
            Telefono = u.Telefono,
            FotoPerfil = u.FotoPerfil,
            PlanId = u.PlanId,
            PlanNombre = plan?.Nombre ?? "",
            TipoConductorId = u.TipoConductorId,
            TipoConductorNombre = tipo?.Nombre ?? "",
            EmpresaId = u.EmpresaId,
            EmpresaRazonSocial = empresa?.RazonSocial,
            Estado = u.Estado,
            UltimoAcceso = u.UltimoAcceso,
            FechaRegistro = u.FechaRegistro
        };
    }
}
