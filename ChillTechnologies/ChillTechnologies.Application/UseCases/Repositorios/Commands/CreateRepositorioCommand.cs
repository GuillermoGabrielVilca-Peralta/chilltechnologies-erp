using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Repositorios.Commands;

public record CreateRepositorioCommand : IRequest<int>
{
    public int? ProductoSoftwareId { get; set; }
    public string Nombre { get; set; } = null!;
    public string Url { get; set; } = null!;
    public string Proveedor { get; set; } = "GitHub";
    public string RamaPrincipal { get; set; } = "main";
    public string Visibilidad { get; set; } = "Privado";
}

internal sealed class CreateRepositorioCommandHandler : IRequestHandler<CreateRepositorioCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateRepositorioCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateRepositorioCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.Repositorio
        {
            ProductoSoftwareId = request.ProductoSoftwareId,
            Nombre = request.Nombre,
            Url = request.Url,
            Proveedor = request.Proveedor,
            RamaPrincipal = request.RamaPrincipal,
            Visibilidad = request.Visibilidad,
            Estado = "Activo",
            FechaRegistro = DateTime.Now
        };

        await _unitOfWork.Repository<Domain.Entities.Repositorio>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}
