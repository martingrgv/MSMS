using System;
using AutoMapper;
using MSMS.Core.Models;
using MSMS.Infrastructure.Data.Models;

namespace MSMS.Core.Profiles
{
    public class ServerProfile : Profile
    {
        public ServerProfile()
        {
            CreateMap<ServerFormModel, Server>();   
            CreateMap<Server, ServerViewModel>()
                .ForMember(dest => dest.OwnerName, opt => 
                    opt.MapFrom(src => src.Owner.UserName))   
                .ForMember(dest => dest.ImagePath, opt =>
                    opt.MapFrom(src => src.ImagePath.Replace(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot"), "")));
            CreateMap<Server, ServerDetailsViewModel>()
                .ForMember(dest => dest.OwnerName, opt => 
                    opt.MapFrom(src => src.Owner.UserName))   
                .ForMember(dest => dest.ImagePath, opt =>
                    opt.MapFrom(src => src.ImagePath.Replace(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot"), "")));
            CreateMap<Server, ServerWorldViewModel>()
                .ForMember(dest => dest.Locations, opt =>
                    opt.MapFrom(src => src.Worlds.SelectMany(w => w.Locations)))
                .ForMember(dest => dest.OwnerName, opt => 
                    opt.MapFrom(src => src.Owner.UserName))   
                .ForMember(dest => dest.ImagePath, opt =>
                    opt.MapFrom(src => src.ImagePath.Replace(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot"), "")));
        }
    }
}
