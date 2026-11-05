using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.ReglasScoring.Commands;

public record CreateReglaScoringCommand : IRequest<int>
{
    // si es null es sistema y si es con valor es de l a empresa
    public int? EmpresaId { get; set; }
    public int TipoEventoId { get; set; }
    public int ImpactoPuntaje { get; set; }
    public decimal Peso { get; set; } = 1.00m;
    public bool Activa { get; set; } = true;
}

internal sealed class CreateReglaScoringCommandHandler : IRequestHandler<CreateReglaScoringCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateReglaScoringCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateReglaScoringCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.ReglasScoring
        {
            EmpresaId = request.EmpresaId,
            TipoEventoId = request.TipoEventoId,
            ImpactoPuntaje = request.ImpactoPuntaje,
            Peso = request.Peso,
            Activa = request.Activa,
            FechaRegistro = DateTime.Now
        };

        await _unitOfWork.Repository<Domain.Entities.ReglasScoring>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}
