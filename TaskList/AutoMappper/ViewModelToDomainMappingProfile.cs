using AutoMapper;
using TaskList.Model.Dto;
using TaskList.Model.Model;

namespace TaskList.Web.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {   
            CreateMap<TarefaDto, Tarefa>();
        }
    }
}
