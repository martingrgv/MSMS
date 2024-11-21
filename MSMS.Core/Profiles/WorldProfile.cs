using System;
using AutoMapper;
using MSMS.Core.Models;
using MSMS.Infrastructure.Data.Models;

namespace MSMS.Core.Profiles;

public class WorldProfile : Profile
{
    public WorldProfile()
    {
        CreateMap<World, ServerWorldViewModel>();
    }
}
