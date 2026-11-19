using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.ParametrosSistema.Commands;

public record CreateParametroSistemaCommand : IRequest<int>
{
    public string Clave { get; set; } = null!;
    public string Valor { get; set; } = null!;
    public string? Descripcion { get; set; }
    public string TipoDato { get; set; } = "string";
    public bool Editable { get; set; } = true;
}

internal sealed class CreateParametroSistemaCommandHandler : IRequestHandler<CreateParametroSistemaCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateParametroSistemaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateParametroSistemaCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.ParametrosSistema
        {
            Clave = request.Clave,
            Valor = request.Valor,
            Descripcion = request.Descripcion,
            TipoDato = request.TipoDato,
            Editable = request.Editable
        };

        await _unitOfWork.Repository<Domain.Entities.ParametrosSistema>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}
