using AutoMapper;
using Sinlist.Models.Entities.Sinlist;
using Sinlist.Shared.DTOs.Sinlists;

namespace Sinlist.API.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<TodoList, TodoListDto>().ReverseMap();
            CreateMap<TodoListItem, TodoListItemDto>().ReverseMap();
        }
    }
}
