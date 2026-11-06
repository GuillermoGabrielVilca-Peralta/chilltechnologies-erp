using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Areas.Commands;

public record CreateAreaCommand : IRequest<int>
{
    public string Nombre { get; set; } = null!;
    public string? Descripcion { get; set; }
    // Null = area raiz del organigrama
    public int? AreaPadreId { get; set; }
}

internal sealed class CreateAreaCommandHandler : IRequestHandler<CreateAreaCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateAreaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateAreaCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.Area
        {
            Nombre = request.Nombre,
            Descripcion = request.Descripcion,
            AreaPadreId = request.AreaPadreId,
            Estado = "Activa",
            FechaRegistro = DateTime.Now
        };

        await _unitOfWork.Repository<Domain.Entities.Area>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}
