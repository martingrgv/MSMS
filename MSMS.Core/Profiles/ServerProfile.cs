using System;
using AutoMapper;
using Microsoft.Data.SqlClient;
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
                .ForMember(dest => dest.ServerId, opt =>
                    opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.WorldType, opt =>
                    opt.Ignore())
                .ForMember(dest => dest.Locations, opt =>
                    opt.Ignore())
                .ForMember(dest => dest.ImagePath, opt =>
                    opt.Ignore())
                .ForMember(dest => dest.ServerName, opt =>
                    opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.OwnerName, opt => 
                    opt.MapFrom(src => src.Owner.UserName));
        }
    }
}
