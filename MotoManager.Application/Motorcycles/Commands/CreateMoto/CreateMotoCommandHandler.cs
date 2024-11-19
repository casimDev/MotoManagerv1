using MediatR;
using Microsoft.EntityFrameworkCore;
using MotoManager.Application.Common.Models;
using MotoManager.Domain.Entities;
using MotoManager.Infraestructure.Data;

namespace MotoManager.Application.Motorcycles.Commands.CreateMoto
{
    public class CreateMotoCommandHandler(IMotorcycleManagerContext context) : IRequestHandler<CreateMotoCommand, Results>
    {
        public async Task<Results> Handle(CreateMotoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Motorcycle? moto = await context.Motorcycles.FirstOrDefaultAsync(p => p.Plate == request.Placa);
                if (moto != null)
                {
                    return Results.Fail(false, "400", "moto já existe no sistema");
                }
                Motorcycle motoToInsert = new Motorcycle()
                {
                    Identificador = request.Identificador,
                    Plate = request.Placa,
                    Model = request.Modelo,
                    Year = request.Ano
                };

                context.Motorcycles.Add(motoToInsert);
                var ret = await context.SaveChangesAsync(cancellationToken);
                return Results.Ok(true, "moto criada com sucesso", [motoToInsert]);

            }
            catch (Exception ex)
            {

                return Results.Fail(false, "400", ex.Message);
            }
        }
    }
}
