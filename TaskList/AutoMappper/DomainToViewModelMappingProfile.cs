using AutoMapper;
using TaskList.Model.Dto;
using TaskList.Model.Model;

namespace TaskList.Web.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Tarefa, TarefaDto>();
        }
    }
}