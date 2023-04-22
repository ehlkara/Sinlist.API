using System;
using Abp.Dependency;
using AutoMapper;
using Sinlist.Models.Entities.Sinlist;
using Sinlist.Shared.DTOs.Sinlists;

namespace Sinlist.BusinessLogic.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            using (var scope = IocManager.Instance.CreateScope())
            {
                CreateMap<TodoList, TodoListDto>().ReverseMap();
                CreateMap<TodoListItem, TodoListItemDto>().ReverseMap();
            }
        }
    }
}

