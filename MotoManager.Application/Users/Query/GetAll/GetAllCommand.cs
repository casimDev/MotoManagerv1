using MediatR;
using MotoManager.Domain.Entities;

namespace MotoManager.Application.Users.Query.GetAll
{
    public record GetAllCommand() : IRequest<IEnumerable<User>>;

}
