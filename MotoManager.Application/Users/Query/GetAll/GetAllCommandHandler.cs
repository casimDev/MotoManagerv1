using MediatR;
using Microsoft.EntityFrameworkCore;
using MotoManager.Domain.Entities;
using MotoManager.Infraestructure.Data;

namespace MotoManager.Application.Users.Query.GetAll
{
    public class GetAllCommandHandler(IMotorcycleManagerContext context) : IRequestHandler<GetAllCommand, IEnumerable<User>>
    {
        public async Task<IEnumerable<User>> Handle(GetAllCommand request, CancellationToken cancellationToken)
        {
            return await context.Users.AsQueryable().Where(p => !p.IsDeleted).ToListAsync();
        }
    }
}
