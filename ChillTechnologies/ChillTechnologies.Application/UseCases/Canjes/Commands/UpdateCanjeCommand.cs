using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Canjes.Commands;

public record UpdateCanjeCommand : IRequest<Unit>
{
    public int Id { get; set; }
    // Pendiente, Usado, Expirado o Anulado
    public string Estado { get; set; } = null!;
}

internal sealed class UpdateCanjeCommandHandler : IRequestHandler<UpdateCanjeCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCanjeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateCanjeCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Canje>();

        var canje = await repo.GetByIdAsync(request.Id);

        canje!.Estado = request.Estado;
        canje.FechaUso = request.Estado == "Usado" ? DateTime.Now : null;

        repo.Update(canje);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}
