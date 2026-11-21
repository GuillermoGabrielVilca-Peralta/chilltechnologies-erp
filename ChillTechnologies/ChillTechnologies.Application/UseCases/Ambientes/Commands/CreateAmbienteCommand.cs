using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Ambientes.Commands;

public record CreateAmbienteCommand : IRequest<int>
{
    public string Nombre { get; set; } = null!;
    public string? Descripcion { get; set; }
    public short Orden { get; set; }
    public bool EsProductivo { get; set; }
}

internal sealed class CreateAmbienteCommandHandler : IRequestHandler<CreateAmbienteCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateAmbienteCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateAmbienteCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.Ambiente
        {
            Nombre = request.Nombre,
            Descripcion = request.Descripcion,
            Orden = request.Orden,
            EsProductivo = request.EsProductivo
        };

        await _unitOfWork.Repository<Domain.Entities.Ambiente>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}
