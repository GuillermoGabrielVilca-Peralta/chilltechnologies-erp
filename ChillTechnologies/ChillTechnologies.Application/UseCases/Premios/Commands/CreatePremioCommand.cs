using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Premios.Commands;

public record CreatePremioCommand : IRequest<int>
{
    public int AliadoId { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Descripcion { get; set; }
    public int PuntosRequeridos { get; set; }
    public int Stock { get; set; }
    public DateOnly? FechaInicio { get; set; }
    public DateOnly? FechaFin { get; set; }
    public string? Imagen { get; set; }
}

internal sealed class CreatePremioCommandHandler : IRequestHandler<CreatePremioCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreatePremioCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreatePremioCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.Premio
        {
            AliadoId = request.AliadoId,
            Nombre = request.Nombre,
            Descripcion = request.Descripcion,
            PuntosRequeridos = request.PuntosRequeridos,
            Stock = request.Stock,
            FechaInicio = request.FechaInicio,
            FechaFin = request.FechaFin,
            Imagen = request.Imagen,
            Estado = "Disponible",
            FechaRegistro = DateTime.Now
        };

        await _unitOfWork.Repository<Domain.Entities.Premio>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}
