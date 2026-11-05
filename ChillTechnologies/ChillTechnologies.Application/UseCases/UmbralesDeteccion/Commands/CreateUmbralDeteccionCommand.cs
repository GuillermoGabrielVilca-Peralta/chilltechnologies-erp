using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.UmbralesDeteccion.Commands;

public record CreateUmbralDeteccionCommand : IRequest<int>
{
    public int ModeloIaId { get; set; }
    public int TipoEventoId { get; set; }
    // Confianza minima 0-100 para aceptar la deteccion
    public decimal ConfianzaMinima { get; set; }
}

internal sealed class CreateUmbralDeteccionCommandHandler : IRequestHandler<CreateUmbralDeteccionCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateUmbralDeteccionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateUmbralDeteccionCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.UmbralesDeteccion
        {
            ModeloIaId = request.ModeloIaId,
            TipoEventoId = request.TipoEventoId,
            ConfianzaMinima = request.ConfianzaMinima
        };

        await _unitOfWork.Repository<Domain.Entities.UmbralesDeteccion>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}
