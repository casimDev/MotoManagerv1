using MediatR;
using Microsoft.EntityFrameworkCore;
using MotoManager.Domain.Entities;
using MotoManager.Infraestructure.Data;

namespace MotoManager.Application.Motorcycles.Query.GetAll
{
    public class GetAllCommandHandler(IMotorcycleManagerContext context) : IRequestHandler<GetAllCommand, ICollection<Motorcycle>>
    {
        public async Task<ICollection<Motorcycle>> Handle(GetAllCommand request, CancellationToken cancellationToken)
        {
            return await context.Motorcycles.ToListAsync(cancellationToken);
        }
    }
}
