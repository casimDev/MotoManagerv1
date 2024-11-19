using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MotoManager.Application.Motorcycles.Commands.CreateMoto;
using MotoManager.Application.Motorcycles.Query.GetAll;
using MotoManager.Dtos;

namespace MotoManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MotoController(ISender sender, IMapper mapper) : ControllerBase
    {
        [HttpPost]
        public async Task<IResult> Create([FromBody] CreateMotoDto moto)
        {
            CreateMotoCommand command = new CreateMotoCommand(moto.Identificador, moto.Modelo, moto.Placa, moto.Ano);
            var ret = await sender.Send(command);
            if (ret.Success)
            {
                return Results.Created("200", ret.Returns);
            }

            return Results.BadRequest(new Dictionary<string, string> { ["mensagem"] = ret.Message });
        }

        [HttpGet]
        public async Task<ICollection<MotoDto>> GetAll()
        {
            GetAllCommand command = new GetAllCommand();
            var ret = await sender.Send(command);
            var mappedList = mapper.Map<ICollection<MotoDto>>(ret);
            return mappedList;
        }


        [HttpDelete("{id}")]
        public async Task<IResult> Delete(Guid id)
        {
            return Results.Ok();
        }

        [HttpPut("{id}")]
        public async Task<IResult> Update(Guid id)
        {
            return Results.Ok();
        }

        [HttpGet("{id}")]
        public async Task<MotoDto> GetById(Guid id)
        {
            return new MotoDto();
        }
    }
}
