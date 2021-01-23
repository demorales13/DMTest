using AutoMapper;

using DMTest.Domain.Entities;
using DMTest.Services.RestServices.ViewModels;

namespace DMTest.Services.RestServices.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Bet, BetNumberCreateViewModel>().ReverseMap();
            //CreateMap<Ciudad, CiudadViewModel>().ReverseMap();
            //CreateMap<Empleado, EmpleadoViewModel>().ReverseMap();
            //CreateMap<TipoDocumento, TipoDocumentoViewModel>().ReverseMap();
            //CreateMap<Cargo, CargoViewModel>().ReverseMap();
        }
    }
}
