using MediatR;
using MotoManager.Application.Common.Models;

namespace MotoManager.Application.Users.Command.CreateUser
{
    public record CreateUserCommand(
        string Name,
        string Email,
        string Password,
        string Role) : IRequest<Results>;
}
