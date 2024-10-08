using System;
using AutoMapper;
using Microsoft.Identity.Client;
using Microsoft.VisualBasic;
using MSMS.Core.Contracts;
using MSMS.Core.Models;
using MSMS.Infrastructure.Data.Common;
using MSMS.Infrastructure.Data.Models;

namespace MSMS.Core.Services
{
    public class ServerService : IServerService
    {
        private IRepository _repository;
        private IMapper _mapper;

        public ServerService(IRepository repository, IMapper mapper)
        {
            _repository = repository;           
            _mapper = mapper;
        }

        public void CreateServer(ServerFormModel model)
        {
        }
    }
}
