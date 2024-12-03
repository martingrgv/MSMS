using AutoMapper;
using MSMS.Core.Models;
using MSMS.Infrastructure.Data.Models;

namespace MSMS.Core.Profiles;

public class TodoProfile : Profile
{
    public TodoProfile()
    { 
        CreateMap<TodoList, TodoViewModel>()
            .ForMember(dest => dest.Todos, opt => 
                opt.MapFrom(src => src.TodoItems))
            .ForMember(dest => dest.TodoCreateModel, opt =>
                opt.Ignore());   
        CreateMap<TodoItem, TodoItemViewModel>();
    }
}
