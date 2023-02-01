using AutoMapper;
using ERPDemo.API.ViewModels;
using ERPDemo.Domain.Entities;

namespace ERPDemo.API.AutoMapper
{
    public class ApiMapper : Profile
    {
        public ApiMapper()
        {
            CreateMap<Grupo, GrupoVMGet>().ReverseMap();

            CreateMap<Grupo, GrupoVMPost>().ReverseMap();
        }
    }
}
