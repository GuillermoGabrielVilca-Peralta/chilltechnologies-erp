using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.CasosPrueba.Commands;

public record CreateCasoPruebaCommand : IRequest<int>
{
    public int HistoriaId { get; set; }
    public string Codigo { get; set; } = null!;
    public string Titulo { get; set; } = null!;
    public string? Precondiciones { get; set; }
    public string Pasos { get; set; } = null!;
    public string ResultadoEsperado { get; set; } = null!;
    public string Tipo { get; set; } = "Funcional";
    public bool Automatizado { get; set; }
}

internal sealed class CreateCasoPruebaCommandHandler : IRequestHandler<CreateCasoPruebaCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateCasoPruebaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateCasoPruebaCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.CasosPrueba
        {
            HistoriaId = request.HistoriaId,
            Codigo = request.Codigo,
            Titulo = request.Titulo,
            Precondiciones = request.Precondiciones,
            Pasos = request.Pasos,
            ResultadoEsperado = request.ResultadoEsperado,
            Tipo = request.Tipo,
            Automatizado = request.Automatizado,
            FechaRegistro = DateTime.Now
        };

        await _unitOfWork.Repository<Domain.Entities.CasosPrueba>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}
