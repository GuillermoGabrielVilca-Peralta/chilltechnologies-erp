using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.TiposAusencia.Commands;

public record CreateTipoAusenciaCommand : IRequest<int>
{
    public string Nombre { get; set; } = null!;
    public bool Remunerada { get; set; } = true;
    public int? DiasMaximos { get; set; }
}

internal sealed class CreateTipoAusenciaCommandHandler : IRequestHandler<CreateTipoAusenciaCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateTipoAusenciaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateTipoAusenciaCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.TiposAusencium
        {
            Nombre = request.Nombre,
            Remunerada = request.Remunerada,
            DiasMaximos = request.DiasMaximos
        };

        await _unitOfWork.Repository<Domain.Entities.TiposAusencium>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}
