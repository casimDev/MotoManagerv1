using AutoMapper;
using MotoManager.Domain.Entities;

namespace MotoManager.Dtos
{
    public class MotoDto
    {
        public string Identificador { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public string Placa { get; set; } = string.Empty;
        public int Ano { get; set; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                this.CreateMap<MotoDto, Motorcycle>().ConvertUsing(p => new Motorcycle()
                {
                    Identificador = p.Identificador,
                    Model = p.Modelo,
                    Year = p.Ano,
                    Plate = p.Placa
                });
            }
        }

    }
}
