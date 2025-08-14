using App.ServiceLayer.Contract.IEntityServices.IExampleServices.DTOs;
using App.UI.Models.ExampleModels;
using AutoMapper;

namespace App.UI.Models.MapperModel
{
    public class APIAutoMapperProfile : Profile
    {
        public APIAutoMapperProfile()
        {

            CreateMap<CreateExampleReqModel, ExampleDTO>().ReverseMap();



        }
    }
}
