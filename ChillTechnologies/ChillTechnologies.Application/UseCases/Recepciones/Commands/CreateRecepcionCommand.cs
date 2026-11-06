using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Recepciones.Commands;

public record CreateRecepcionCommand : IRequest<int>
{
    public int OrdenCompraId { get; set; }
    public int AlmacenId { get; set; }
    public string? NumeroGuia { get; set; }
    public DateOnly FechaRecepcion { get; set; }
    public int? EmpleadoId { get; set; }
    //parcial completa rechazada
    public string Estado { get; set; } = "Parcial";
    public string? Observaciones { get; set; }
}

internal sealed class CreateRecepcionCommandHandler : IRequestHandler<CreateRecepcionCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateRecepcionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateRecepcionCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.Recepcione
        {
            OrdenCompraId = request.OrdenCompraId,
            AlmacenId = request.AlmacenId,
            NumeroGuia = request.NumeroGuia,
            FechaRecepcion = request.FechaRecepcion,
            EmpleadoId = request.EmpleadoId,
            Estado = request.Estado,
            Observaciones = request.Observaciones,
            FechaRegistro = DateTime.Now
        };

        await _unitOfWork.Repository<Domain.Entities.Recepcione>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}
