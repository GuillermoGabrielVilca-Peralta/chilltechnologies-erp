using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Geocercas.Commands;

public record UpdateGeocercaCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Descripcion { get; set; }
    public decimal Latitud { get; set; }
    public decimal Longitud { get; set; }
    public int RadioMetros { get; set; }
    public string Tipo { get; set; } = null!;
    // Activa o Inactiva
    public string Estado { get; set; } = null!;
}

internal sealed class UpdateGeocercaCommandHandler : IRequestHandler<UpdateGeocercaCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateGeocercaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateGeocercaCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Geocerca>();

        var item = await repo.GetByIdAsync(request.Id);

        item!.Nombre = request.Nombre;
        item.Descripcion = request.Descripcion;
        item.Latitud = request.Latitud;
        item.Longitud = request.Longitud;
        item.RadioMetros = request.RadioMetros;
        item.Tipo = request.Tipo;
        item.Estado = request.Estado;

        repo.Update(item);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
