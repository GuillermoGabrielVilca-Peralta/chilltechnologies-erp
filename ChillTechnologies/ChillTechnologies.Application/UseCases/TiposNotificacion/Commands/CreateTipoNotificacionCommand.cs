using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.TiposNotificacion.Commands;

public record CreateTipoNotificacionCommand : IRequest<int>
{
    public string Nombre { get; set; } = null!;
    // Push, Email, SMS o Interna
    public string Canal { get; set; } = "Push";
}

internal sealed class CreateTipoNotificacionCommandHandler : IRequestHandler<CreateTipoNotificacionCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateTipoNotificacionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateTipoNotificacionCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.TiposNotificacion
        {
            Nombre = request.Nombre,
            Canal = request.Canal
        };

        await _unitOfWork.Repository<Domain.Entities.TiposNotificacion>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}
