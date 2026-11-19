using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Auditoria.Commands;

public record RegistrarAuditoriaCommand : IRequest<int>
{
    public int? UsuarioSistemaId { get; set; }
    public string Accion { get; set; } = null!;
    public string? TablaAfectada { get; set; }
    public int? RegistroId { get; set; }
    public string? DatosAntes { get; set; }
    public string? DatosDespues { get; set; }
    public string? DireccionIp { get; set; }
}

internal sealed class RegistrarAuditoriaCommandHandler : IRequestHandler<RegistrarAuditoriaCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public RegistrarAuditoriaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(RegistrarAuditoriaCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.Auditorium
        {
            UsuarioSistemaId = request.UsuarioSistemaId,
            Accion = request.Accion,
            TablaAfectada = request.TablaAfectada,
            RegistroId = request.RegistroId,
            DatosAntes = request.DatosAntes,
            DatosDespues = request.DatosDespues,
            DireccionIp = request.DireccionIp,
            FechaAccion = DateTime.Now
        };

        await _unitOfWork.Repository<Domain.Entities.Auditorium>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}
