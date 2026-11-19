using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.VersionesProducto.Commands;

public record CreateVersionProductoCommand : IRequest<int>
{
    public int ProductoSoftwareId { get; set; }
    public string Numero { get; set; } = null!;
    public string? NotasVersion { get; set; }
}

internal sealed class CreateVersionProductoCommandHandler : IRequestHandler<CreateVersionProductoCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateVersionProductoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateVersionProductoCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.VersionesProducto
        {
            ProductoSoftwareId = request.ProductoSoftwareId,
            Numero = request.Numero,
            NotasVersion = request.NotasVersion,
            Estado = "Planificada",
            FechaRegistro = DateTime.Now
        };

        await _unitOfWork.Repository<Domain.Entities.VersionesProducto>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}
