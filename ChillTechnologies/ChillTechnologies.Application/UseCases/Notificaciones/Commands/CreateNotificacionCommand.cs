using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Notificaciones.Commands;

public record CreateNotificacionCommand : IRequest<int>
{
    public int UsuarioId { get; set; }
    public int TipoNotificacionId { get; set; }
    public string Titulo { get; set; } = null!;
    public string Mensaje { get; set; } = null!;
}

internal sealed class CreateNotificacionCommandHandler : IRequestHandler<CreateNotificacionCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateNotificacionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateNotificacionCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.Notificacione
        {
            UsuarioId = request.UsuarioId,
            TipoNotificacionId = request.TipoNotificacionId,
            Titulo = request.Titulo,
            Mensaje = request.Mensaje,
            Leida = false,
            FechaEnvio = DateTime.Now
        };

        await _unitOfWork.Repository<Domain.Entities.Notificacione>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}
