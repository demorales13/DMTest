using AutoMapper;

using DMTest.Domain.Entities;
using DMTest.Services.RestServices.ViewModels;

namespace DMTest.Services.RestServices.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Roulette, RouletteCloseViewModel>().ReverseMap();
            //CreateMap<Departamento, DepartamentoViewModel>().ReverseMap();
            //CreateMap<Ciudad, CiudadViewModel>().ReverseMap();
            //CreateMap<Empleado, EmpleadoViewModel>().ReverseMap();
            //CreateMap<TipoDocumento, TipoDocumentoViewModel>().ReverseMap();
            //CreateMap<Cargo, CargoViewModel>().ReverseMap();
        }
    }
}
