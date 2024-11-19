using MediatR;
using MotoManager.Application.Common.Models;

namespace MotoManager.Application.Motorcycles.Commands.CreateMoto
{
    public record CreateMotoCommand(string Identificador,
        string Modelo,
        string Placa,
        int Ano) : IRequest<Results>;
}
