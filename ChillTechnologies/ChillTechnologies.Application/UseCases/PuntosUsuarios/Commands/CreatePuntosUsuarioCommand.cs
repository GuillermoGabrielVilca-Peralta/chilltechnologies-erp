using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.PuntosUsuarios.Commands;

// La llave primaria es el propio usuario_id, no un id autogenerado
public record CreatePuntosUsuarioCommand : IRequest<int>
{
    public int UsuarioId { get; set; }
    public int NivelId { get; set; }
}

internal sealed class CreatePuntosUsuarioCommandHandler : IRequestHandler<CreatePuntosUsuarioCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreatePuntosUsuarioCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreatePuntosUsuarioCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.PuntosUsuario
        {
            UsuarioId = request.UsuarioId,
            NivelId = request.NivelId,
            PuntosActuales = 0,
            PuntosHistoricos = 0,
            UltimaActualizacion = DateTime.Now
        };

        await _unitOfWork.Repository<Domain.Entities.PuntosUsuario>().Insert(data);
        await _unitOfWork.Complete();
        return data.UsuarioId;
    }
}
