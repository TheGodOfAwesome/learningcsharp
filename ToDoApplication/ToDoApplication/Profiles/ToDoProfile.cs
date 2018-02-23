using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using ToDoApplication.Entities;
using ToDoApplication.Enums;
using ToDoApplication.Models;

namespace ToDoApplication.Profiles
{
    public class ToDoProfile : Profile
    {
        public ToDoProfile()
        {
            CreateMap<ToDoItem, ToDoTable>()
                .ForMember(s => s.Priority, m => m.MapFrom(s => s.Priority.ToString("g")))
                .ReverseMap()
                .ForMember(s => s.Priority,
                    m => m.MapFrom(s => (Priorities) Enum.Parse(typeof(Priorities), s.Priority.ToString())));
        }
    }
}