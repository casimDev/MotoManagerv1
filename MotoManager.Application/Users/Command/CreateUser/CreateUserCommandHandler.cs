using System.Text;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MotoManager.Application.Common.Models;
using MotoManager.Infraestructure.Data;
using User = MotoManager.Domain.Entities.User;

namespace MotoManager.Application.Users.Command.CreateUser
{
    public class CreateUserCommandHandler(IMotorcycleManagerContext context) : IRequestHandler<CreateUserCommand, Results>
    {
        public async Task<Results> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                User? existentUser = await context.Users.FirstOrDefaultAsync(p => p.Email == request.Email, cancellationToken);

                if (existentUser != null)
                {
                    return Results.Fail(false, "400", "Usuário já existente");
                }

                User user = new User()
                {
                    Email = request.Email,
                    Name = request.Name,
                    Password = Convert.ToBase64String(Encoding.UTF8.GetBytes(request.Password)),
                    Role = request.Role,
                    CreatedAt = DateTime.UtcNow
                };
                context.Users.Add(user);
                var ret = await context.SaveChangesAsync(cancellationToken);
                return Results.Ok(true, "Usuário criado com sucesso", [user]);
            }
            catch (Exception ex)
            {

                return Results.Fail(false, "500", ex.Message);
            }
        }
    }
}
