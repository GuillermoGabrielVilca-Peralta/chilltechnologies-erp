using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Canjes.Commands;

public record CreateCanjeCommand : IRequest<int>
{
    public int UsuarioId { get; set; }
    public int PremioId { get; set; }
    public int PuntosUtilizados { get; set; }
}

internal sealed class CreateCanjeCommandHandler : IRequestHandler<CreateCanjeCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateCanjeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateCanjeCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.Canje
        {
            UsuarioId = request.UsuarioId,
            PremioId = request.PremioId,
            PuntosUtilizados = request.PuntosUtilizados,
            FechaCanje = DateTime.Now,
            Estado = "Pendiente"
            // CodigoQr lo genera Postgres con pgcrypto
        };

        await _unitOfWork.Repository<Domain.Entities.Canje>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}
