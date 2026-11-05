using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Aliados.Commands;

public record CreateAliadoCommand : IRequest<int>
{
    public string Nombre { get; set; } = null!;
    public string? Ruc { get; set; }
    public int CategoriaId { get; set; }
    public string? Direccion { get; set; }
    public string? Distrito { get; set; }
    public string? Telefono { get; set; }
    public string? Email { get; set; }
    public string? Logo { get; set; }
    public string? Descripcion { get; set; }
    public decimal ComisionPorcentaje { get; set; }
}

internal sealed class CreateAliadoCommandHandler : IRequestHandler<CreateAliadoCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateAliadoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateAliadoCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.Aliado
        {
            Nombre = request.Nombre,
            Ruc = request.Ruc,
            CategoriaId = request.CategoriaId,
            Direccion = request.Direccion,
            Distrito = request.Distrito,
            Telefono = request.Telefono,
            Email = request.Email,
            Logo = request.Logo,
            Descripcion = request.Descripcion,
            ComisionPorcentaje = request.ComisionPorcentaje,
            Estado = "Activo",
            FechaRegistro = DateTime.Now
        };

        await _unitOfWork.Repository<Domain.Entities.Aliado>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}
