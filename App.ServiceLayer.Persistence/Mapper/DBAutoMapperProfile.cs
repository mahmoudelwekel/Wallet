using App.Domain.Entities.App;
using App.ServiceLayer.Contract.IEntityServices.IExampleServices.DTOs;
using AutoMapper;

namespace App.ServiceLayer.Persistence.Mapper
{
    public class DBAutoMapperProfile : Profile
    {
        public DBAutoMapperProfile()
        {



            CreateMap<Example, ExampleDTO>().ReverseMap();

        }
    }
}
